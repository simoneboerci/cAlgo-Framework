using cAlgo.API;

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
            if (_strategy?.Account?.History.Count >= DataSample)
            {
                if (GetDynamicBias() > (SimulationThreshold / 100.0))
                {
                    double riskAdjusted = RiskPerTrade + RiskPerTrade * GetDynamicBias() * (DynamicFactor / 100.0);
                    return CalculatePercentagePositionSize(riskAdjusted);
                }
                else return 0.01;
            }
            else
            {
                if (SimulateInitialTrades) return 0.01;
            }

            return CalculatePercentagePositionSize(RiskPerTrade);
        }

        protected virtual double GetDynamicBias()
        {
            switch (_strategy?.CurrentSignal)
            {
                case TradeType.Buy:
                    return _strategy.PerformanceMonitor.LongWins / _strategy.PerformanceMonitor.Wins;
                case TradeType.Sell:
                    return _strategy.PerformanceMonitor.ShortWins / _strategy.PerformanceMonitor.Wins;
                default:
                    return 0;
            }
        }

        #endregion

        #endregion
    }
}
