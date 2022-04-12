namespace cAlgoUnityFramework.Strategies.Modules
{
    public abstract class TakeProfitModule : StrategyModule
    {
        #region Public Variables

        public bool AddSpread { get; private set; }

        #endregion

        #region Public Methods

        public TakeProfitModule(bool addSpread) => AddSpread = addSpread;

        public double GetTakeProfitPips()
        {
            if (AddSpread && _strategy != null) return CalculateTakeProfitPips() + _strategy.MarketData.Symbol.Spread;
            else return CalculateTakeProfitPips();
        }

        #endregion

        #region Protected Methods

        protected abstract double CalculateTakeProfitPips();

        #endregion
    }
}
