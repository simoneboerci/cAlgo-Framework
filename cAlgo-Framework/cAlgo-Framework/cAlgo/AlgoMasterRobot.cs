using cAlgo.API;

using cAlgoUnityFramework.Unity;

namespace cAlgoUnityFramework.cAlgo
{
    public abstract class AlgoMasterRobot : Robot
    {
        #region Protected Variables

        protected readonly UnityMasterRobot _unityMasterRobot;

        #endregion

        #region Methods

        #region Public Methods

        public AlgoMasterRobot() => _unityMasterRobot = new UnityMasterRobot(this);

        #endregion

        #region Protected Methods

        protected abstract void Main();

        #region cAlgo Life Cycle

        protected sealed override void OnStart()
        {
            Main();

            _unityMasterRobot.Start();
        }

        protected sealed override void OnBar()
        {
            _unityMasterRobot.FixedUpdate();
        }
        protected sealed override void OnTick()
        {
            _unityMasterRobot.Update();
            _unityMasterRobot.LateUpdate();
        }

        protected sealed override void OnStop()
        {
            _unityMasterRobot.Stop();
        }
        protected sealed override void OnError(Error error)
        {
            Print(error);

            _unityMasterRobot.Stop();
        }

        #endregion

        #endregion

        #endregion
    }
}
