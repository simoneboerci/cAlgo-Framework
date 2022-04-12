namespace cAlgoUnityFramework.Strategies.Modules
{
    public class FixedTakeProfitModule : TakeProfitModule
    {
        #region Public Variables

        public double TakeProfitPips { get; private set; }

        #endregion

        #region Methods

        #region Public Methods

        public FixedTakeProfitModule(double takeProfitPips, bool addSpread) : base(addSpread)
        {
            if (takeProfitPips <= 0) TakeProfitPips = 100;
            else TakeProfitPips = takeProfitPips;
        }

        #endregion

        #region Protected Methods

        protected override double CalculateTakeProfitPips() => TakeProfitPips;

        #endregion

        #endregion
    }
}
