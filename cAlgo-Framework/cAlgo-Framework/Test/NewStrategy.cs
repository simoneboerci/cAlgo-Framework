using cAlgoUnityFramework.Strategies;

namespace cAlgoUnityFramework.Test
{
    internal class NewStrategy : StrategyBase
    {
        #region Protected Methods

        protected override void LookForOpportunities()
        {
            if(CanTrade()) 
        }

        #endregion
    }
}
