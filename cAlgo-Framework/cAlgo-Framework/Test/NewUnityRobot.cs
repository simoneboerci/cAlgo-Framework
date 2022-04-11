using cAlgoUnityFramework.Strategies;
using cAlgoUnityFramework.Unity;

namespace cAlgoUnityFramework.Test
{
    interface class NewUnityRobot : UnityRobot
    {
        #region Public Methods

        public NewUnityRobot(StrategyBase strategy) : base(strategy)
        {

        }

        #endregion
    }
}
