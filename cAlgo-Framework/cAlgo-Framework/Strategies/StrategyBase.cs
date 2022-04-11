using cAlgo.API;

using cAlgoUnityFramework.Unity;

namespace cAlgoUnityFramework.Strategies
{
    public abstract class StrategyBase : IStrategy
    {
        #region Public Variables

        public MarketData MarketData { get; private set; }

        #endregion

        #region Protected Variables

        protected UnityRobot? _unityRobot;

        #endregion

        #region Methods

        #region Public Methods

        public StrategyBase(MarketData marketData) => MarketData = marketData;

        public void AttachTo(UnityRobot unityRobot) => _unityRobot = unityRobot;
        public void Detach() => _unityRobot = null;

        public void Execute()
        {
            if (CanTrade()) LookForOpportunities();
        }

        #endregion

        #region Protected Methods

        protected abstract void LookForOpportunities();

        protected virtual bool CanTrade() => true;

        #endregion

        #endregion
    }
}
