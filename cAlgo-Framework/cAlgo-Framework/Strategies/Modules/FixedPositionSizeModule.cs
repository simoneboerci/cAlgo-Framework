namespace cAlgoUnityFramework.Strategies.Modules
{
    public class FixedPositionSizeModule : PositionSizeModule
    {
        #region Public Variables

        public double LotSize { get; private set; }

        #endregion

        #region Methods

        #region Public Methods

        public FixedPositionSizeModule(double lotSize, StrategyBase strategyBase) : base(strategyBase)
        {
            if (lotSize < 0.01) LotSize = 0.01;
            else LotSize = lotSize;
        }

        #endregion

        #region Protected Methods

        protected override double GetLotSize() => LotSize;

        #endregion

        #endregion
    }
}
