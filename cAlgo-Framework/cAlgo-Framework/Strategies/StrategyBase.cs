namespace cAlgoUnityFramework.Strategies
{
    public abstract class StrategyBase : IStrategy
    {
        #region Public Methods

        public void Execute()
        {
            if (CanTrade()) LookForOpportunities();
        }

        #endregion

        #region Protected Methods

        protected abstract void LookForOpportunities();

        protected virtual bool CanTrade() => true;

        #endregion
    }
}
