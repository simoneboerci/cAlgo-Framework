using cAlgo.API;

using cAlgoUnityFramework.Strategies;
using cAlgoUnityFramework.Data;

namespace cAlgoUnityFramework.Unity
{
    public abstract class UnityRobot : UnityRobotBase, IRobot
    {
        #region Public Variables

        public readonly UnityMasterRobot UnityMasterRobot;

        public string Name { get; private set; }
        public Account Account { get; private set; }
        public StrategyBase? Strategy { get; private set; }

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

        #region Methods 

        #region Public Methods

        public UnityRobot(UnityMasterRobot unityMasterRobot, string name)
        {
            UnityMasterRobot = unityMasterRobot;

            Account = new Account(this, UnityMasterRobot.Account.Balance);

            Name = name;
        }

        public override void Stop()
        {
            ResetEvents();

            base.Stop();
        }

        public SPerformanceSnapshot GetPerformanceSnapshot()
        {
            SPerformanceSnapshot performanceSnapshot = new SPerformanceSnapshot
                (
                    Account.NetProfit,
                    Strategy.PerformanceMonitor.ProfitFactor,
                    new SDrawdown(Strategy.Account.MaxBalanceDrawdown, Strategy.Account.MaxEquityDrawdown),
                    new STrades(Strategy.PerformanceMonitor.WinningTrades, Strategy.PerformanceMonitor.LosingTrades, Strategy.PerformanceMonitor.MaxConsecutiveWins, Strategy.PerformanceMonitor.MaxConsecutiveLosses)
                );

            return performanceSnapshot;
        }

        #region Orders

        #region Execute Market Orders

        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.ExecuteBuyOrder(symbolName, volume, label); }
        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label, double? stopLossPips) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.ExecuteBuyOrder(symbolName, volume, label, stopLossPips); }
        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.ExecuteBuyOrder(symbolName, volume, label, stopLossPips, takeProfitPips); }
        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.ExecuteBuyOrder(symbolName, volume, label, stopLossPips, takeProfitPips, hasTrailingStop); }

        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.ExecuteSellOrder(symbolName, volume, label); }
        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label, double? stopLossPips) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.ExecuteSellOrder(symbolName, volume, label, stopLossPips); }
        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.ExecuteSellOrder(symbolName, volume, label, stopLossPips, takeProfitPips); }
        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.ExecuteSellOrder(symbolName, volume, label, stopLossPips, takeProfitPips, hasTrailingStop); }


        #endregion

        #region Place Market Range Orders

        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.ExecuteBuyRangeOrder(symbolName, volume, marketRangePips, basePrice, label); }
        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.ExecuteBuyRangeOrder(symbolName, volume, marketRangePips, basePrice, label, stopLossPips); }
        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.ExecuteBuyRangeOrder(symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips); }
        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.ExecuteBuyRangeOrder(symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, hasTrailingStop); }

        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.ExecuteSellRangeOrder(symbolName, volume, marketRangePips, basePrice, label); }
        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.ExecuteSellRangeOrder(symbolName, volume, marketRangePips, basePrice, label, stopLossPips); }
        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.ExecuteSellRangeOrder(symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips); }
        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.ExecuteSellRangeOrder(symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, hasTrailingStop); }


        #endregion

        #region Place Limit Orders

        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyLimitOrder(symbolName, volume, targetPrice, label); }
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyLimitOrder(symbolName, volume, targetPrice, label, stopLossPips); }
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyLimitOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips); }
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyLimitOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration); }
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyLimitOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration, hasTrailingStop); }

        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellLimitOrder(symbolName, volume, targetPrice, label); }
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellLimitOrder(symbolName, volume, targetPrice, label, stopLossPips); }
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellLimitOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips); }
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellLimitOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration); }
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellLimitOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration, hasTrailingStop); }

        #endregion

        #region Place Stop-Limit Orders

        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label); }
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips); }
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips); }
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips, expiration); }
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips, expiration, hasTrailingStop); }

        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label); }
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips); }
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips); }
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips, expiration); }
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellStopLimitOrder(symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips, expiration, hasTrailingStop); }

        #endregion

        #region Place Stop Orders

        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyStopOrder(symbolName, volume, targetPrice, label); }
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyStopOrder(symbolName, volume, targetPrice, label, stopLossPips); }
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyStopOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips);}
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyStopOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration);}
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) { Strategy?.UpdateSignal(TradeType.Buy); return UnityMasterRobot.PlaceBuyStopOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration, hasTrailingStop); }

        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellStopOrder(symbolName, volume, targetPrice, label); }
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellStopOrder(symbolName, volume, targetPrice, label, stopLossPips); }
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellStopOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips); }
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellStopOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration); }
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) { Strategy?.UpdateSignal(TradeType.Sell); return UnityMasterRobot.PlaceSellStopOrder(symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration, hasTrailingStop); }

        #endregion

        #region Modify Pending Orders

        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice) => UnityMasterRobot.ModifyPendingOrder(pendingOrder, targetPrice);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips) => UnityMasterRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLossPips);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips, double? takeProfitPips) => UnityMasterRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLossPips, takeProfitPips);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => UnityMasterRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLossPips, takeProfitPips, expiration);

        #endregion

        #region Cancel Pending Orders

        public TradeResult CancelPendingOrder(PendingOrder pendingOrder) => UnityMasterRobot.CancelPendingOrder(pendingOrder);

        #endregion

        #endregion

        #region Positions

        #region Modify Positions

        public TradeResult ModifyPosition(Position position, double volume) => UnityMasterRobot.ModifyPosition(position, volume);
        public TradeResult ModifyPosition(Position position, double volume, double? stopLossPips) => UnityMasterRobot.ModifyPosition(position, volume, stopLossPips);
        public TradeResult ModifyPosition(Position position, double? stopLossPips, double? takeProfitPips) => UnityMasterRobot.ModifyPosition(position, stopLossPips, takeProfitPips);
        public TradeResult ModifyPosition(Position position, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) => UnityMasterRobot.ModifyPosition(position, stopLossPips, takeProfitPips, hasTrailingStop);

        #endregion

        #region Reverse Positions

        public TradeResult ReversePosition(Position position) => UnityMasterRobot.ReversePosition(position);
        public TradeResult ReversePosition(Position position, double volume) => UnityMasterRobot.ReversePosition(position, volume);

        #endregion

        #region Close Positions

        public TradeResult ClosePosition(Position position) => UnityMasterRobot.ClosePosition(position);
        public TradeResult ClosePosition(Position position, double volume) => UnityMasterRobot.ClosePosition(position, volume);

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
            if (strategy != null)
            {
                if (Strategy != null) Strategy.Detach();

                Strategy = strategy;
                Strategy.AttachTo(this);
            }
        }

        #endregion

        #endregion

        #region Private Methods

        #region Events

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

        #endregion
    }
}