using cAlgoUnityFramework.Unity;

namespace cAlgoUnityFramework.Strategies
{
    public abstract class StrategyBase : IStrategy
    {
        #region Protected Variables

        protected readonly UnityRobot _unityRobot;

        #endregion

        #region Methods

        #region Public Methods

        public StrategyBase(UnityRobot unityRobot) => _unityRobot = unityRobot;

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
