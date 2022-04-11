namespace cAlgoUnityFramework.Unity
{
    public abstract class UnityRobotBase
    {
        #region Public Methods

        public virtual void Run()
        {
            Awake();
            Start();
        }

        public virtual void Stop()
        {
            Disable();
            Destroy();
        }

        public virtual void Awake() { }
        public virtual void Start() { }

        public virtual void FixedUpdate() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }

        public virtual void Disable() { }
        public virtual void Destroy() { }

        #endregion
    }
}
