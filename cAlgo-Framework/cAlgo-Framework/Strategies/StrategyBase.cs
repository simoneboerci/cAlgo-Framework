using cAlgo.API;

using cAlgoUnityFramework.Unity;
using cAlgoUnityFramework.Strategies.Modules;

namespace cAlgoUnityFramework.Strategies
{
    public abstract class StrategyBase : IStrategy
    {
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

        #region Methods

        #region Public Methods

        public StrategyBase(MarketData marketData, PositionSizeModule positionSizeModule, StopLossModule stopLossModule, TakeProfitModule takeProfitModule)
        {
            MarketData = marketData;

            PositionSizeModule = positionSizeModule;
            StopLossModule = stopLossModule;
            TakeProfitModule = takeProfitModule;
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

        #region Set Module

        public void SetModule(PositionSizeModule positionSizeModule)
        {
            PositionSizeModule = positionSizeModule;
            PositionSizeModule.SetStrategy(this);
        }
        public void SetModule(StopLossModule stopLossModule)
        {
            StopLossModule = stopLossModule;
            StopLossModule.SetStrategy(this);
        }
        public void SetModule(TakeProfitModule takeProfitModule)
        {
            TakeProfitModule = takeProfitModule;
            TakeProfitModule.SetStrategy(this);
        }

        #endregion

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
