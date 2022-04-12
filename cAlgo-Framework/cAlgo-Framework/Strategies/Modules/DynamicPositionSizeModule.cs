namespace cAlgoUnityFramework.Strategies.Modules
{
    public class DynamicPositionSizeModule : PercentagePositionSizeModule
    {
        #region Public Variables

        public int DataSample { get; private set; }
        public int SimulationThreshold { get; private set; }
        public int DynamicFactor { get; private set; }
        public bool SimulateInitialTrades { get; private set; }

        #endregion

        #region Methods

        #region Public Methods

        public DynamicPositionSizeModule(double riskPerTrade, int dataSample, int simulationThreshold, int dynamicFactor, bool simulateInitialTrades, StopLossModule stopLossModule) : base(riskPerTrade, stopLossModule)
        {
            if (dataSample <= 0) DataSample = 100;
            else DataSample = dataSample;

            if (simulationThreshold < 0) SimulationThreshold = 0;
            else if(simulationThreshold > 100) SimulationThreshold = 100;
            else SimulationThreshold = simulationThreshold;

            if (dynamicFactor <= 0 || dynamicFactor > 100) DynamicFactor = 100;
            else DynamicFactor = dynamicFactor;

            SimulateInitialTrades = simulateInitialTrades;
        }

        #endregion

        #region Protected Methods

        protected override double GetLotSize()
        {
            return base.GetLotSize();
        }

        #endregion

        #endregion
    }
}
