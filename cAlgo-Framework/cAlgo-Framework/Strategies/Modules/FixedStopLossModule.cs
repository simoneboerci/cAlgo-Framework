﻿namespace cAlgoUnityFramework.Strategies.Modules
{
    public class FixedStopLossModule : StopLossModule
    {
        #region Public Variables

        public double StopLossPips { get; private set; }

        #endregion

        #region Methods

        #region Public Methods

        public FixedStopLossModule(StrategyBase strategyBase, double stopLossPips, bool addSpread) : base(strategyBase, addSpread)
        {
            if (stopLossPips <= 0) StopLossPips = 100;
            else StopLossPips = stopLossPips;
        }

        #endregion

        #region Protected Methods

        protected override double CalculateStopLossPips() => StopLossPips;

        #endregion

        #endregion
    }
}
