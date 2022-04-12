using System;
using System.Collections.Generic;
using System.Linq;
namespace cAlgoUnityFramework.Strategies.Modules
{
    public class PercentagePositionSizeModule : PositionSizeModule
    {
        #region Variables

        #region Public Methods

        public double RiskPerTrade { get; private set; }

        #endregion

        #region Protected Variables

        protected readonly StopLossModule _stopLossModule;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public PercentagePositionSizeModule(double riskPerTrade, StopLossModule stopLossModule)
        {
            if (riskPerTrade <= 0) RiskPerTrade = 1;
            else if(riskPerTrade > 100) RiskPerTrade = 100;
            else RiskPerTrade = riskPerTrade;

            _stopLossModule = stopLossModule;
        }

        #endregion

        #region Protected Methods

        protected override double GetLotSize()
        {
            if (_strategy == null || _strategy.Account == null) return 0.01;

            return CalculatePercentagePositionSize(RiskPerTrade);
        }

        protected double CalculatePercentagePositionSize(double riskPerTrade) => (_strategy.Account.Balance / 100.0 * riskPerTrade) / _stopLossModule.GetStopLossPips() / 10.0;

        #endregion

        #endregion
    }
}
