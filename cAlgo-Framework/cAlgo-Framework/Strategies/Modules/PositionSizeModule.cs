namespace cAlgoUnityFramework.Strategies.Modules
{
    public abstract class PositionSizeModule : StrategyModule
    {
        #region Methods

        #region Public Methods

        public double GetPositionSize() => GetVolumeFromLotSize(GetLotSize());

        #endregion

        #region Protected Methods

        protected abstract double GetLotSize();

        #endregion

        #region Private Methods

        private double GetVolumeFromLotSize(double lotSize)
        {
            if (_strategy == null) return 1000;

            return _strategy.MarketData.Symbol.NormalizeVolumeInUnits(_strategy.MarketData.Symbol.QuantityToVolumeInUnits(lotSize));
        }

        #endregion

        #endregion
    }
}
