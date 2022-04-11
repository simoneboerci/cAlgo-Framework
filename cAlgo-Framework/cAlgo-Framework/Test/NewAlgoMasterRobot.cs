using cAlgo.API;

using cAlgoUnityFramework.cAlgo;
using cAlgoUnityFramework.Unity;
using cAlgoUnityFramework.Strategies;

namespace cAlgoUnityFramework.Test
{
    internal class NewAlgoMasterRobot : AlgoMasterRobot
    {
        #region Protected Methods

        protected override void Main()
        {
            UnityMasterRobot unityMasterRobot = new(this);

            TimeFrame timeFrame = TimeFrame.Daily;
          
            MarketData marketData = new(Symbol, timeFrame, MarketData.GetBars(timeFrame));
            StrategyBase strategy = new NewStrategy(marketData);

            UnityRobot unityRobot = _unityMasterRobot.CreateRobot(new NewUnityRobot(unityMasterRobot, "Test Robot"));

            unityRobot.SetStrategy(strategy);
        }

        #endregion
    }
}
