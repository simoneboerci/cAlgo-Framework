using cAlgoUnityFramework.cAlgo;
using cAlgoUnityFramework.Unity;

namespace cAlgoUnityFramework.Test
{
    internal class NewAlgoMasterRobot : AlgoMasterRobot
    {
        #region Protected Methods

        protected override void Main()
        {
            UnityRobot unityRobot = _unityMasterRobot.CreateRobot(new NewUnityRobot(new NewStrategy()));
        }

        #endregion
    }
}
