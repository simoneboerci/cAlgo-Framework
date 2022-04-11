using cAlgo.API;

namespace cAlgoUnityFramework.cAlgo
{
    public interface IAlgoMasterRobot
    {
        #region Methods

        #region Public Methods

        public void Stop();

        public TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label);
        public TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLossPips);
        public TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration);
        public TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop);

        public TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label);
        public TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips);
        public TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop);

        public TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label);
        public TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips);
        public TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop);

        public TradeResult CancelPendingOrder(PendingOrder pendingOrder);

        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips, double? takeProfitPips);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips, double? takeProfitPips, DateTime? expiration);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop, double? stopLimitRangePips);

        public TradeResult ReversePosition(Position position);
        public TradeResult ReversePosition(Position position, double volume);

        public TradeResult ClosePosition(Position position);
        public TradeResult ClosePosition(Position position, double volume);

        public TradeResult ModifyPosition(Position position, double volume);
        public TradeResult ModifyPosition(Position position, double volume, double? stopLossPips);
        public TradeResult ModifyPosition(Position position, double volume, double? stopLossPips, double? takeProfitPips);
        public TradeResult ModifyPosition(Position position, double volume, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop);

        public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label);
        public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips);
        public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration);
        public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop);

        public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label);
        public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLossPips);
        public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips);
        public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration);
        public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop);

        #endregion

        #region Protected Methods

        protected internal void OnStart();
        protected internal void OnStop();
        protected internal void OnTick();
        protected internal void OnBar();
        protected internal void OnError(Error error);

        protected internal void OnPositionOpened(Position openedPosition);
        protected internal void OnPositionClosed(Position position);
        protected internal void OnPendingOrderCreated(PendingOrder newOrder);

        #endregion

    #endregion
    }
}
