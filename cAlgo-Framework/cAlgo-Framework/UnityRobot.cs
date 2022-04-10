using cAlgo.API;
using cAlgoUnityFramework.Strategies;

namespace cAlgoUnityFramework
{
    public abstract class UnityRobot
    {
        #region Public Variables

        public StrategyBase Strategy { get; private set; }

        #endregion

        #region Public Methods

        public UnityRobot(StrategyBase strategy) => Strategy = strategy;

        #region Unity Life Cycle

        public virtual void Awake() { }
        public virtual void Start() { }

        public virtual void FixedUpdate() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }

        public virtual void Disable() { }
        public virtual void Destroy() { }

        #endregion

        #region Setters

        public void SetStrategy(StrategyBase strategy)
        {
            if (strategy != null) Strategy = strategy;
        }

        #endregion

        #endregion
    }
}