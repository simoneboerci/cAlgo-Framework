﻿using cAlgo.API;

using cAlgoUnityFramework.Strategies;

namespace cAlgoUnityFramework.Unity
{
    public abstract class UnityRobot : UnityRobotBase, IUnityMasterRobot
    {
        #region Variables

        #region Public Variables


        public StrategyBase Strategy { get; private set; }

        #endregion

        #region Protected Variables

        protected readonly UnityMasterRobot _unityMasterRobot;

        #endregion

        #endregion

        #region Public Methods

        public UnityRobot(UnityMasterRobot unityMasterRobot, StrategyBase strategy)
        {
            _unityMasterRobot = unityMasterRobot;

            Strategy = strategy;  
        }

        #region Orders

        #region Execute Market Orders

        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label) => _unityMasterRobot.ExecuteBuyOrder(symbolName, volume, label);
        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label, double? stopLossPips) => _unityMasterRobot.ExecuteBuyOrder(symbolName, volume, label, stopLossPips);
        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips) => _unityMasterRobot.ExecuteBuyOrder(symbolName, volume, label, stopLossPips, takeProfitPips);
        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) => _unityMasterRobot.ExecuteBuyOrder(symbolName, volume, label, stopLossPips, takeProfitPips, hasTrailingStop);

        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label) => _unityMasterRobot.ExecuteSellOrder(symbolName, volume, label);
        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label, double? stopLossPips) => _unityMasterRobot.ExecuteSellOrder(symbolName, volume, label, stopLossPips);
        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips) => _unityMasterRobot.ExecuteSellOrder(symbolName, volume, label, stopLossPips, takeProfitPips);
        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) => _unityMasterRobot.ExecuteSellOrder(symbolName, volume, label, stopLossPips, takeProfitPips, hasTrailingStop);


        #endregion

        #region Place Market Range Orders

        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label) => _unityMasterRobot.ExecuteBuyRangeOrder(symbolName, volume, marketRangePips, basePrice, label);
        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips) => _unityMasterRobot.ExecuteBuyRangeOrder(symbolName, volume, marketRangePips, basePrice, label, stopLossPips);
        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips) => _unityMasterRobot.ExecuteBuyRangeOrder(symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips);
        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) => _unityMasterRobot.ExecuteBuyRangeOrder(symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, hasTrailingStop);

        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label) => _unityMasterRobot.ExecuteSellRangeOrder(symbolName, volume, marketRangePips, basePrice, label);
        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips) => _unityMasterRobot.ExecuteSellRangeOrder(symbolName, volume, marketRangePips, basePrice, label, stopLossPips);
        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips) => _unityMasterRobot.ExecuteSellRangeOrder(symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips);
        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) => _unityMasterRobot.ExecuteSellRangeOrder(symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, hasTrailingStop);


        #endregion

        #region Place Limit Orders

        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label) => _unityMasterRobot.PlaceBuyLimitOrder(symbolName, volume, targetPrice, label);
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips) => _unityMasterRobot.PlaceBuyLimitOrder(symbolName, volume, targetPrice, label, stopLossPips);
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips) => _unityMasterRobot.PlaceBuyLimitOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips);
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _unityMasterRobot.PlaceBuyLimitOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration);
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) => _unityMasterRobot.PlaceBuyLimitOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration, hasTrailingStop);

        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label) => _unityMasterRobot.PlaceSellLimitOrder(symbolName, volume, targetPrice, label);
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips) => _unityMasterRobot.PlaceSellLimitOrder(symbolName, volume, targetPrice, label, stopLossPips);
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips) => _unityMasterRobot.PlaceSellLimitOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips);
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _unityMasterRobot.PlaceSellLimitOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration);
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) => _unityMasterRobot.PlaceSellLimitOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration, hasTrailingStop);

        #endregion

        #region Place Stop-Limit Orders

        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label) => _unityMasterRobot.PlaceBuyStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label);
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips) => _unityMasterRobot.PlaceBuyStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips);
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips) => _unityMasterRobot.PlaceBuyStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips);
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _unityMasterRobot.PlaceBuyStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips, expiration);
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) => _unityMasterRobot.PlaceBuyStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips, expiration, hasTrailingStop);

        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label) => _unityMasterRobot.PlaceSellStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label);
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips) => _unityMasterRobot.PlaceSellStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips);
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips) => _unityMasterRobot.PlaceSellStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips);
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _unityMasterRobot.PlaceSellStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips, expiration);
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) => _unityMasterRobot.PlaceSellStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips, expiration, hasTrailingStop);

        #endregion

        #region Place Stop Orders

        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label) => _unityMasterRobot.PlaceBuyStopOrder(symbolName, volume, targetPrice, label);
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips) => _unityMasterRobot.PlaceBuyStopOrder(symbolName, volume, targetPrice, label, stopLossPips);
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips) => _unityMasterRobot.PlaceBuyStopOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips);
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _unityMasterRobot.PlaceBuyStopOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration);
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) => _unityMasterRobot.PlaceBuyStopOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration, hasTrailingStop);

        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label) => _unityMasterRobot.PlaceSellStopOrder(symbolName, volume, targetPrice, label);
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips) => _unityMasterRobot.PlaceSellStopOrder(symbolName, volume, targetPrice, label, stopLossPips);
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips) => _unityMasterRobot.PlaceSellStopOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips);
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _unityMasterRobot.PlaceSellStopOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration);
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) => _unityMasterRobot.PlaceSellStopOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration, hasTrailingStop);

        #endregion

        #region Modify Pending Orders

        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice) => _unityMasterRobot.ModifyPendingOrder(pendingOrder, targetPrice);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips) => _unityMasterRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLossPips);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips, double? takeProfitPips) => _unityMasterRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLossPips, takeProfitPips);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _unityMasterRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLossPips, takeProfitPips, expiration);

        #endregion

        #region Cancel Pending Orders

        public TradeResult CancelPendingOrder(PendingOrder pendingOrder) => _unityMasterRobot.CancelPendingOrder(pendingOrder);

        #endregion

        #endregion

        #region Positions

        #region Modify Positions

        public TradeResult ModifyPosition(Position position, double volume) => _unityMasterRobot.ModifyPosition(position, volume);
        public TradeResult ModifyPosition(Position position, double volume, double? stopLossPips) => _unityMasterRobot.ModifyPosition(position, volume, stopLossPips);
        public TradeResult ModifyPosition(Position position, double? stopLossPips, double? takeProfitPips) => _unityMasterRobot.ModifyPosition(position, stopLossPips, takeProfitPips);
        public TradeResult ModifyPosition(Position position, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) => _unityMasterRobot.ModifyPosition(position, stopLossPips, takeProfitPips, hasTrailingStop);

        #endregion

        #region Reverse Positions

        public TradeResult ReversePosition(Position position) => _unityMasterRobot.ReversePosition(position);
        public TradeResult ReversePosition(Position position, double volume) => _unityMasterRobot.ReversePosition(position, volume);

        #endregion

        #region Close Positions

        public TradeResult ClosePosition(Position position) => _unityMasterRobot.ClosePosition(position);
        public TradeResult ClosePosition(Position position, double volume) => _unityMasterRobot.ClosePosition(position, volume);

        #endregion

        #endregion

        #region Setters

        public void SetStrategy(StrategyBase strategy)
        {
            if (strategy != null) Strategy = strategy;
        }

        #endregion

        #endregion
    }
}