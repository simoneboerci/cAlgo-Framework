using cAlgoUnityFramework.cAlgo;

namespace cAlgoUnityFramework.Test
{
    internal class NewAlgoMasterRobot : AlgoMasterRobot
    {
        #region Protected Methods

        protected override void Main()
        {
            _unityMasterRobot.CreateRobot(new NewUnityRobot(new NewStrategy()));
        }

        #endregion
    }
}
