using cAlgo.API;

using cAlgoUnityFramework.Unity;
using cAlgoUnityFramework.Strategies.Modules;

namespace cAlgoUnityFramework.Strategies
{
    public abstract class StrategyBase : IStrategy
    {
        #region Variables

        #region Public Variables

        public Account? Account { get { return _unityRobot?.Account; } }

        public MarketData MarketData { get; private set; }

        public TradeType CurrentSignal { get; private set; }
        public TradeType PreviousSignal { get; private set; }

        public StrategyPerformanceMonitor? PerformanceMonitor { get; private set; }

        #region Risk Management

        public PositionSizeModule PositionSizeModule { get; private set; }
        public StopLossModule StopLossModule { get; private set; }
        public TakeProfitModule TakeProfitModule { get; private set; } 

        #endregion

        #region Events

        public event Action<Position>? OnWin;
        public event Action<Position>? OnLoss;
        public event Action<Position>? OnTakeProfit;
        public event Action<Position>? OnStopLoss;

        #endregion

        #endregion

        #region Protected Variables

        protected UnityRobot? _unityRobot;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public StrategyBase(MarketData marketData, PositionSizeModule positionSizeModule, StopLossModule stopLossModule, TakeProfitModule takeProfitModule)
        {
            MarketData = marketData;

            PositionSizeModule = positionSizeModule;
            StopLossModule = stopLossModule;
            TakeProfitModule = takeProfitModule;

            PositionSizeModule.SetStrategy(this);
            StopLossModule.SetStrategy(this);
            TakeProfitModule.SetStrategy(this);
        }

        public void Execute()
        {
            if (CanTrade()) LookForOpportunities();
        }

        #region Attach / Detach

        public void AttachTo(UnityRobot unityRobot)
        {
            _unityRobot = unityRobot;

            PerformanceMonitor = new(this);

            _unityRobot.PositionClosed += OnPositionClosed;
        }
        public void Detach()
        {
            if(_unityRobot != null) _unityRobot.PositionClosed -= OnPositionClosed;

            _unityRobot = null;       
        }

        #endregion

        #region Orders

        #region Execute Market Orders

        public TradeResult ExecuteBuyOrder() => _unityRobot.ExecuteBuyOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips());
        public TradeResult ExecuteSellOrder() => _unityRobot.ExecuteSellOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips());

        #endregion

        #region Execute Buy Range Orders

        public TradeResult ExecuteBuyRangeOrder(double marketRangePips, double basePrice) => _unityRobot.ExecuteBuyRangeOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), marketRangePips, basePrice, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips());
        public TradeResult ExecuteSellRangeOrder(double marketRangePips, double basePrice) => _unityRobot.ExecuteSellRangeOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), marketRangePips, basePrice, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips());

        #endregion

        #region Place Limit Orders

        public TradeResult PlaceBuyLimitOrder(double targetPrice) => _unityRobot.PlaceBuyLimitOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), targetPrice, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips());
        public TradeResult PlaceBuyLimitOrder(double targetPrice, DateTime? expiration) => _unityRobot.PlaceBuyLimitOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), targetPrice, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips(), expiration);

        public TradeResult PlaceSellLimitOrder(double targetPrice) => _unityRobot.PlaceSellLimitOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), targetPrice, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips());
        public TradeResult PlaceSellLimitOrder(double targetPrice, DateTime? expiration) => _unityRobot.PlaceSellLimitOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), targetPrice, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips(), expiration);

        #endregion

        #region Place Stop-Limit Orders

        public TradeResult PlaceBuyStopLimitOrder(double targetPrice, double stopLimitRangePips) => _unityRobot.PlaceBuyStopLimitOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), targetPrice, stopLimitRangePips, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips());
        public TradeResult PlaceBuyStopLimitOrder(double targetPrice, double stopLimitRangePips, DateTime? expiration) => _unityRobot.PlaceBuyStopLimitOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), targetPrice, stopLimitRangePips, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips(), expiration);

        public TradeResult PlaceSellStopLimitOrder(double targetPrice, double stopLimitRangePips) => _unityRobot.PlaceSellStopLimitOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), targetPrice, stopLimitRangePips, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips());
        public TradeResult PlaceSellStopLimitOrder(double targetPrice, double stopLimitRangePips, DateTime? expiration) => _unityRobot.PlaceSellStopLimitOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), stopLimitRangePips, targetPrice, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips(), expiration);

        #endregion

        #region Place Stop Orders

        public TradeResult PlaceBuyStopOrder(double targetPrice) => _unityRobot.PlaceBuyStopOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), targetPrice, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips());
        public TradeResult PlaceBuyStopOrder(double targetPrice, DateTime? expiration) => _unityRobot.PlaceBuyStopOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), targetPrice, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips(), expiration);

        public TradeResult PlaceSellStopOrder(double targetPrice) => _unityRobot.PlaceSellStopOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), targetPrice, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips());
        public TradeResult PlaceSellStopOrder(double targetPrice, DateTime? expiration) => _unityRobot.PlaceSellStopOrder(MarketData.SymbolName, PositionSizeModule.GetPositionSize(), targetPrice, _unityRobot.Name, StopLossModule.GetStopLossPips(), TakeProfitModule.GetTakeProfitPips(), expiration);

        #endregion

        #endregion

        public void UpdateSignal(TradeType currentSignal)
        {
            PreviousSignal = CurrentSignal;
            CurrentSignal = currentSignal;
        }

        #endregion

        #region Protected Methods

        protected abstract void LookForOpportunities();

        protected virtual bool CanTrade() => true;

        #endregion

        #region Private Methods

        private void OnPositionClosed(PositionClosedEventArgs args)
        {
            if (args.Position.NetProfit >= 0) OnWin?.Invoke(args.Position);
            else OnLoss?.Invoke(args.Position);

            if(args.Reason == PositionCloseReason.TakeProfit) OnTakeProfit?.Invoke(args.Position);
            else if(args.Reason == PositionCloseReason.StopLoss) OnStopLoss?.Invoke(args.Position);
        }

        #endregion

        #endregion
    }
}
