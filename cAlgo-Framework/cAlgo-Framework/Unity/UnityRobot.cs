using cAlgoUnityFramework.Strategies;

namespace cAlgoUnityFramework.Unity
{
    public abstract class UnityRobot : UnityRobotBase
    {
        #region Public Variables

        public StrategyBase Strategy { get; private set; }

        #endregion

        #region Public Methods

        public UnityRobot(StrategyBase strategy) => Strategy = strategy;

        #region Setters

        public void SetStrategy(StrategyBase strategy)
        {
            if (strategy != null) Strategy = strategy;
        }

        #endregion

        #endregion
    }
}