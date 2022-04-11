using cAlgoUnityFramework.Strategies;

namespace cAlgoUnityFramework.Unity
{
    public abstract class UnityRobot : UnityRobotBase
    {
        #region Variables

        #region Public Variables

        public StrategyBase Strategy { get; private set; }

        #endregion

        #region Protected Variables

        protected readonly UnityMasterRobot _unityMasterRobot;

        #endregion

        #endregion

        #region Public Methods

        public UnityRobot(UnityMasterRobot unityMasterRobot, StrategyBase strategy)
        {
            _unityMasterRobot = unityMasterRobot;

            Strategy = strategy;  
        }

        #region Setters

        public void SetStrategy(StrategyBase strategy)
        {
            if (strategy != null) Strategy = strategy;
        }

        #endregion

        #endregion
    }
}