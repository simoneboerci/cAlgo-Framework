using cAlgo.API;

using cAlgoUnityFramework.Strategies;

namespace cAlgoUnityFramework.Unity
{
    public abstract class UnityRobot : UnityRobotBase, IRobot
    {
        #region Variables

        #region Public Variables

        public string Name { get; private set; }
        public Account Account { get; private set; }
        public MarketData MarketData { get; private set; }
        public StrategyBase Strategy { get; private set; }

        #region Events

        public event Action<PositionOpenedEventArgs>? PositionOpened;
        public event Action<PositionClosedEventArgs>? PositionClosed;
        public event Action<PositionModifiedEventArgs>? PositionModified;

        public event Action<PendingOrderCreatedEventArgs>? PendingOrderCreated;
        public event Action<PendingOrderFilledEventArgs>? PendingOrderFilled;
        public event Action<PendingOrderModifiedEventArgs>? PendingOrderModified;
        public event Action<PendingOrderCancelledEventArgs>? PendingOrderCancelled;

        #endregion

        #endregion

        #region Protected Variables

        protected readonly UnityMasterRobot _unityMasterRobot;

        #endregion

        #endregion

        #region Methods 

        #region Public Methods

        public UnityRobot(UnityMasterRobot unityMasterRobot, string name, MarketData marketData, StrategyBase strategy)
        {
            _unityMasterRobot = unityMasterRobot;

            Account = new Account(this, _unityMasterRobot.Account.Balance);

            Name = name;
            MarketData = marketData;
            Strategy = strategy;
        }

        public override void Stop()
        {
            ResetEvents();

            base.Stop();
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

        #region Callbacks

        public void OnPositionOpened(PositionOpenedEventArgs args) => PositionOpened?.Invoke(args);
        public void OnPositionClosed(PositionClosedEventArgs args) => PositionClosed?.Invoke(args);
        public void OnPositionModified(PositionModifiedEventArgs args) => PositionModified?.Invoke(args);

        public void OnPendingOrderCreated(PendingOrderCreatedEventArgs args) => PendingOrderCreated?.Invoke(args);
        public void OnPendingOrderFilled(PendingOrderFilledEventArgs args) => PendingOrderFilled?.Invoke(args);
        public void OnPendingOrderModified(PendingOrderModifiedEventArgs args) => PendingOrderModified?.Invoke(args);    
        public void OnPendingOrderCancelled(PendingOrderCancelledEventArgs args) => PendingOrderCancelled?.Invoke(args);

        #endregion

        #region Setters

        public void SetStrategy(StrategyBase strategy)
        {
            if (strategy != null) Strategy = strategy;
        }

        #endregion

        #endregion

        #region Private Methods

        private void ResetEvents()
        {
            PositionOpened = null;
            PositionClosed = null;
            PositionModified = null;

            PendingOrderCreated = null;
            PendingOrderFilled = null;
            PendingOrderModified = null;
            PendingOrderCancelled = null;
        }

        #endregion

        #endregion
    }
}