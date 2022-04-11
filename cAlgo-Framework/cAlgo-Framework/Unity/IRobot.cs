using cAlgo.API;

namespace cAlgoUnityFramework.Unity
{
    public interface IRobot
    {
        #region Public Methods

        #region Orders

        #region Market Orders

        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label);
        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label, double? stopLossPips);
        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop);

        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label);
        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label, double? stopLossPips);
        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop);

        #endregion

        #region Market Range Orders

        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label);
        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips);
        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop);

        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label);
        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips);
        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop);

        #endregion

        #region Limit Orders

        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label);
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips);
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration);
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop);

        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label);
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips);
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration);
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop);

        #endregion

        #region Stop Limit Orders

        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label);
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips);
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration);
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop);

        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label);
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips);
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration);
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop);

        #endregion

        #region Stop Orders

        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label);
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips);
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration);
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop);

        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label);
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips);
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration);
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop);

        #endregion

        #region Modify Pending Orders

        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips, double? takeProfitPips);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips, double? takeProfitPips, DateTime? expiration);

        #endregion

        #region Cancel Pending Orders

        public TradeResult CancelPendingOrder(PendingOrder pendingOrder);

        #endregion

        #endregion

        #region Positions

        #region Modify Positions

        public TradeResult ModifyPosition(Position position, double volume);
        public TradeResult ModifyPosition(Position position, double volume, double? stopLossPips);
        public TradeResult ModifyPosition(Position position, double? stopLossPips, double? takeProfitPips);
        public TradeResult ModifyPosition(Position position, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop);

        #endregion

        #region Reverse Positions

        public TradeResult ReversePosition(Position position);
        public TradeResult ReversePosition(Position position, double volume);

        #endregion

        #region Close Positions

        public TradeResult ClosePosition(Position position);
        public TradeResult ClosePosition(Position position, double volume);

        #endregion

        #endregion

        #region Callbacks

        public void OnPositionOpened(PositionOpenedEventArgs args);
        public void OnPositionClosed(PositionClosedEventArgs args);
        public void OnPositionModified(PositionModifiedEventArgs args);

        public void OnPendingOrderCreated(PendingOrderCreatedEventArgs args);
        public void OnPendingOrderFilled(PendingOrderFilledEventArgs args);
        public void OnPendingOrderModified(PendingOrderModifiedEventArgs args);
        public void OnPendingOrderCancelled(PendingOrderCancelledEventArgs args);

        #endregion

        #endregion
    }
}
