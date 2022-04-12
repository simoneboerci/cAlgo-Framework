namespace cAlgoUnityFramework.Strategies.Modules
{
    public abstract class StrategyModule
    {
        #region Protected Variables

        protected StrategyBase? _strategy;

        #endregion

        #region Public Methods

        public void SetStrategy(StrategyBase strategyBase) => _strategy = strategyBase;

        #endregion
    }
}
