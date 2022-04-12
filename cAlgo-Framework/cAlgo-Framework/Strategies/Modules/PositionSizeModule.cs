namespace cAlgoUnityFramework.Strategies.Modules
{
    public abstract class PositionSizeModule : StrategyModule
    {
        #region Methods

        #region Public Methods

        public PositionSizeModule(StrategyBase strategyBase) : base(strategyBase) { }

        public double GetPositionSize() => GetVolumeFromLotSize(GetLotSize());

        #endregion

        #region Protected Methods

        protected abstract double GetLotSize();

        #endregion

        #region Private Methods

        private double GetVolumeFromLotSize(double lotSize)
        {
            return _strategy.MarketData.Symbol.NormalizeVolumeInUnits(_strategy.MarketData.Symbol.QuantityToVolumeInUnits(lotSize));
        }

        #endregion

        #endregion
    }
}
