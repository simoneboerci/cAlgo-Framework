using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cAlgoUnityFramework.Strategies.Modules
{
    public class StopBasedTakeProfitModule : TakeProfitModule
    {
        #region Public Variables

        public double TakeProfitSize { get; private set; }

        #endregion

        #region Protected Variables

        protected readonly StopLossModule _stopLossModule;

        #endregion

        #region Methods

        #region Public Methods

        public StopBasedTakeProfitModule(StrategyBase strategy, double takeProfitSize, StopLossModule stopLossModule, bool addSpread) : base(strategy, addSpread)
        {
            if (takeProfitSize <= 0) TakeProfitSize = 1;
            else TakeProfitSize = takeProfitSize;

            _stopLossModule = stopLossModule;
        }

        #endregion

        #region Protected Methods

        protected override double CalculateTakeProfitPips()
        {
            if (_stopLossModule.AddSpread) return (_stopLossModule.GetStopLossPips() - _strategy.MarketData.Symbol.Spread) * TakeProfitSize;
            else return _stopLossModule.GetStopLossPips() * TakeProfitSize;
        }

        #endregion

        #endregion
    }
}
