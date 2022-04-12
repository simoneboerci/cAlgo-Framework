namespace cAlgoUnityFramework.Strategies.Modules
{
    public abstract class StopLossModule : StrategyModule
    {
        #region Public Variables

        public bool AddSpread { get; private set; }

        #endregion

        #region Public Methods

        public StopLossModule(bool addSpread) => AddSpread = addSpread;

        public double GetStopLossPips()
        {
            if (AddSpread && _strategy != null) return CalculateStopLossPips() + _strategy.MarketData.Symbol.Spread;
            else return CalculateStopLossPips();
        }

        #endregion

        #region Protected Methods

        protected abstract double CalculateStopLossPips();

        #endregion
    }
}
