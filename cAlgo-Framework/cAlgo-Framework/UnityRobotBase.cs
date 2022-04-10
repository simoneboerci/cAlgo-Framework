namespace cAlgoUnityFramework
{
    public abstract class UnityRobotBase
    {
        #region Public Methods

        public void Run()
        {
            Awake();
            Start();
        }

        public void Stop()
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
