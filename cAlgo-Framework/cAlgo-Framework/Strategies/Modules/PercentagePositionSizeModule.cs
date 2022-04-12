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

        public PercentagePositionSizeModule(double riskPerTrade, StopLossModule stopLossModule, StrategyBase strategyBase) : base(strategyBase)
        {
            if (riskPerTrade <= 0) RiskPerTrade = 1;
            else if(riskPerTrade > 100) RiskPerTrade = 100;
            else RiskPerTrade = riskPerTrade;

            _stopLossModule = stopLossModule;
        }

        #endregion

        #region Protected Methods

        protected override double GetLotSize() => (_strategy.Account.Balance / 100.0 * RiskPerTrade) / _stopLossModule.GetStopLossPips() / 10.0;

        #endregion

        #endregion
    }
}
