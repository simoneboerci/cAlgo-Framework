using cAlgo.API;

using cAlgoUnityFramework.Unity;

namespace cAlgoUnityFramework.Strategies
{
    public abstract class StrategyBase : IStrategy
    {
        #region Public Variables

        public Account? Account { get { return _unityRobot?.Account; } }

        public MarketData MarketData { get; private set; }

        public TradeType CurrentSignal { get; private set; }
        public TradeType PreviousSignal { get; private set; }

        public StrategyPerformanceMonitor? Performance { get; private set; }

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

        public StrategyBase(MarketData marketData) => MarketData = marketData;

        public void Execute()
        {
            if (CanTrade()) LookForOpportunities();
        }

        #region Attach / Detach

        public void AttachTo(UnityRobot unityRobot)
        {
            _unityRobot = unityRobot;

            Performance = new(this);

            _unityRobot.PositionClosed += OnPositionClosed;
        }
        public void Detach()
        {
            _unityRobot.PositionClosed -= OnPositionClosed;

            _unityRobot = null;       
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
