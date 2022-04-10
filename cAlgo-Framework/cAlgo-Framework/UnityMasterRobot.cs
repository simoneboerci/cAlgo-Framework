namespace cAlgoUnityFramework
{
    public abstract class UnityMasterRobot : UnityRobotBase
    {
        #region Protected Variables

        protected List<UnityRobot> _unityRobots = new();

        #endregion

        #region Methods

        #region Public Methods

        #region Unity Life Cycle

        public override void FixedUpdate()
        {
            if (_unityRobots.Count <= 0) return;

            foreach(UnityRobot unityRobot in _unityRobots)
            {
                unityRobot.FixedUpdate();
            }
        }
        public override void Update()
        {
            if (_unityRobots.Count <= 0) return;

            foreach (UnityRobot unityRobot in _unityRobots)
            {
                unityRobot.Update();
            }
        }
        public override void LateUpdate()
        {
            if (_unityRobots.Count <= 0) return;

            foreach (UnityRobot unityRobot in _unityRobots)
            {
                unityRobot.LateUpdate();
            }
        }

        public override void Disable()
        {
            if (_unityRobots.Count <= 0) return;

            foreach (UnityRobot unityRobot in _unityRobots)
            {
                unityRobot.Stop();
            }
        }
        public override void Destroy()
        {
            if (_unityRobots.Count <= 0) return;

            foreach (UnityRobot unityRobot in _unityRobots)
            {
                unityRobot.Stop();
            }
        }

        #endregion

        #region Manage Robots

        public void CreateRobot(UnityRobot unityRobot)
        {
            unityRobot.Start();
            AddRobot(unityRobot);
        }
        public void DestroyRobot(UnityRobot unityRobot)
        {
            unityRobot.Stop();
            RemoveRobot(unityRobot);
        }

        public UnityRobot GetRobot(int index) => _unityRobots[index];

        #endregion

        #endregion

        #region Private Methods

        public void AddRobot(UnityRobot unityRobot) => _unityRobots.Add(unityRobot);
        public void RemoveRobot(UnityRobot unityRobot) => _unityRobots.Remove(unityRobot);

        #endregion

        #endregion
    }
}
