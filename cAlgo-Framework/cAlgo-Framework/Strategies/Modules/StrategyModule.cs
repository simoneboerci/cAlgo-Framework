namespace cAlgoUnityFramework.Strategies.Modules
{
    public abstract class StrategyModule
    {
        #region Protected Variables

        protected readonly StrategyBase _strategy;

        #endregion

        #region Public Methods

        public StrategyModule(StrategyBase strategyBase) => _strategy = strategyBase;

        #endregion
    }
}
