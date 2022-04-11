using cAlgoUnityFramework.Unity;
using cAlgoUnityFramework.Strategies;

namespace cAlgoUnityFramework.Test
{
    internal class NewStrategy : StrategyBase
    {
        #region Public Methods

        public NewStrategy(MarketData marketData) : base(marketData) { }

        #endregion

        #region Protected Methods

        protected override void LookForOpportunities()
        {
            if (CanTrade()) _unityRobot?.ExecuteBuyOrder(MarketData.SymbolName, 1000, _unityRobot.Name);
        }

        #endregion
    }
}
