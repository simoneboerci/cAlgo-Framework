using cAlgo.API;
using cAlgo.API.Internals;

using cAlgoUnityFramework.cAlgo;
using cAlgoUnityFramework.Data;

namespace cAlgoUnityFramework.Unity
{
    public class UnityMasterRobot : UnityRobotBase, IRobot
    {
        #region Variables 

        #region Public Variables

        public double BalanceDrawdown { get { return _algoMasterRobot.BalanceDrawdown; } }
        public double EquityDrawdown { get { return _algoMasterRobot.EquityDrawdown; } }

        public IAccount Account { get { return _algoMasterRobot.Account; } }

        #endregion

        #region Protected Variables

        protected List<UnityRobot> _unityRobots = new();

        #endregion

        #region Private Variables

        private readonly AlgoMasterRobot _algoMasterRobot;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public UnityMasterRobot(AlgoMasterRobot algoMasterRobot) => _algoMasterRobot = algoMasterRobot;

        #region Start / Stop

        public sealed override void Start()
        {
            SetupEvents();

            base.Start();
        }
        public sealed override void Stop()
        {
            if(_unityRobots.Count > 0)
            {
                foreach(UnityRobot unityRobot in _unityRobots)
                {
                    unityRobot.Stop();
                }
            }

            base.Stop();
        }

        #endregion

        #region Unity Life Cycle

        public sealed override void FixedUpdate()
        {
            if (_unityRobots.Count <= 0) return;

            foreach(UnityRobot unityRobot in _unityRobots)
            {
                unityRobot.FixedUpdate();
            }
        }
        public sealed override void Update()
        {
            if (_unityRobots.Count <= 0) return;

            foreach (UnityRobot unityRobot in _unityRobots)
            {
                if(unityRobot.Strategy != null) unityRobot.Strategy.MarketData.ServerTimeInUTC = _algoMasterRobot.Server.TimeInUtc;
                unityRobot.Account.UpdateEquity();
                unityRobot.Update();
            }
        }
        public sealed override void LateUpdate()
        {
            if (_unityRobots.Count <= 0) return;

            foreach (UnityRobot unityRobot in _unityRobots)
            {
                unityRobot.LateUpdate();
            }
        }

        public sealed override void Disable()
        {
            if (_unityRobots.Count <= 0) return;

            foreach (UnityRobot unityRobot in _unityRobots)
            {
                unityRobot.Stop();
            }
        }
        public sealed override void Destroy()
        {
            if (_unityRobots.Count <= 0) return;

            foreach (UnityRobot unityRobot in _unityRobots)
            {
                unityRobot.Stop();
            }
        }

        #endregion

        #region Manage Robots

        public UnityRobot CreateRobot(UnityRobot unityRobot)
        {
            unityRobot.Start();
            AddRobot(unityRobot);
            return unityRobot;
        }
        public UnityRobot DestroyRobot(UnityRobot unityRobot)
        {
            unityRobot.Stop();
            RemoveRobot(unityRobot);
            return unityRobot;
        }

        public int RobotCount => _unityRobots.Count;

        public UnityRobot? GetRobotByIndex(int index)
        {
            if (index >= 0 && index < _unityRobots.Count) return _unityRobots[index];
            else return null;
        }
        public UnityRobot? GetRobotByName(string name)
        {
            foreach(UnityRobot unityRobot in _unityRobots)
            {
                if (unityRobot.Name.Equals(name)) return unityRobot;
            }

            return null;
        }

        #endregion

        #region Orders

        #region Execute Market Orders

        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label) => _algoMasterRobot.ExecuteMarketOrder(TradeType.Buy, symbolName, volume, label);
        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label, double? stopLossPips) => _algoMasterRobot.ExecuteMarketOrder(TradeType.Buy, symbolName, volume, label, stopLossPips, null);
        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips) => _algoMasterRobot.ExecuteMarketOrder(TradeType.Buy, symbolName, volume, label, stopLossPips, takeProfitPips);
        public TradeResult ExecuteBuyOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) => _algoMasterRobot.ExecuteMarketOrder(TradeType.Buy, symbolName, volume, label, stopLossPips, takeProfitPips, "", hasTrailingStop);

        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label) => _algoMasterRobot.ExecuteMarketOrder(TradeType.Sell, symbolName, volume, label);
        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label, double? stopLossPips) => _algoMasterRobot.ExecuteMarketOrder(TradeType.Sell, symbolName, volume, label, stopLossPips, null);
        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips) => _algoMasterRobot.ExecuteMarketOrder(TradeType.Sell, symbolName, volume, label, stopLossPips, takeProfitPips);
        public TradeResult ExecuteSellOrder(string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) => _algoMasterRobot.ExecuteMarketOrder(TradeType.Sell, symbolName, volume, label, stopLossPips, takeProfitPips, "", hasTrailingStop);


        #endregion

        #region Place Market Range Orders

        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label) => _algoMasterRobot.ExecuteMarketRangeOrder(TradeType.Buy, symbolName, volume, marketRangePips, basePrice, label);
        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips) => _algoMasterRobot.ExecuteMarketRangeOrder(TradeType.Buy, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, null);
        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips) => _algoMasterRobot.ExecuteMarketRangeOrder(TradeType.Buy, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips);
        public TradeResult ExecuteBuyRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) => _algoMasterRobot.ExecuteMarketRangeOrder(TradeType.Buy, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, "", hasTrailingStop);

        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label) => _algoMasterRobot.ExecuteMarketRangeOrder(TradeType.Sell, symbolName, volume, marketRangePips, basePrice, label);
        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips) => _algoMasterRobot.ExecuteMarketRangeOrder(TradeType.Buy, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, null);
        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips) => _algoMasterRobot.ExecuteMarketRangeOrder(TradeType.Buy, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips);
        public TradeResult ExecuteSellRangeOrder(string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) => _algoMasterRobot.ExecuteMarketRangeOrder(TradeType.Buy, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, "", hasTrailingStop);


        #endregion

        #region Place Limit Orders

        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label) => _algoMasterRobot.PlaceLimitOrder(TradeType.Buy, symbolName, volume, targetPrice, label);
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips) => _algoMasterRobot.PlaceLimitOrder(TradeType.Buy, symbolName, volume, targetPrice, label, stopLossPips, null);
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips) => _algoMasterRobot.PlaceLimitOrder(TradeType.Buy, symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips);
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _algoMasterRobot.PlaceLimitOrder(TradeType.Buy, symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration);
        public TradeResult PlaceBuyLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) => _algoMasterRobot.PlaceLimitOrder(TradeType.Buy, symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration, "", hasTrailingStop);

        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label) => _algoMasterRobot.PlaceLimitOrder(TradeType.Sell, symbolName, volume, targetPrice, label);
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips) => _algoMasterRobot.PlaceLimitOrder(TradeType.Sell, symbolName, volume, targetPrice, label, stopLossPips, null);
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips) => _algoMasterRobot.PlaceLimitOrder(TradeType.Sell, symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips);
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _algoMasterRobot.PlaceLimitOrder(TradeType.Sell, symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration);
        public TradeResult PlaceSellLimitOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) => _algoMasterRobot.PlaceLimitOrder(TradeType.Sell, symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration, "", hasTrailingStop);

        #endregion

        #region Place Stop-Limit Orders

        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label) => _algoMasterRobot.PlaceStopLimitOrder(TradeType.Buy, symbolName, volume, targetPrice, stopLimitRangePips, label);
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips) => _algoMasterRobot.PlaceStopLimitOrder(TradeType.Buy, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, null);
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips) => _algoMasterRobot.PlaceStopLimitOrder(TradeType.Buy, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips);
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _algoMasterRobot.PlaceStopLimitOrder(TradeType.Buy, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips, expiration);
        public TradeResult PlaceBuyStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) => _algoMasterRobot.PlaceStopLimitOrder(TradeType.Buy, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips, expiration, "", hasTrailingStop);

        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label) => _algoMasterRobot.PlaceStopLimitOrder(TradeType.Sell, symbolName, volume, targetPrice, stopLimitRangePips, label);
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips) => _algoMasterRobot.PlaceStopLimitOrder(TradeType.Sell, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, null);
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips) => _algoMasterRobot.PlaceStopLimitOrder(TradeType.Sell, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips);
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _algoMasterRobot.PlaceStopLimitOrder(TradeType.Sell, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips, expiration);
        public TradeResult PlaceSellStopLimitOrder(string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) => _algoMasterRobot.PlaceStopLimitOrder(TradeType.Sell, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLossPips, takeProfitPips, expiration, "", hasTrailingStop);

        #endregion

        #region Place Stop Orders

        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label) => _algoMasterRobot.PlaceStopOrder(TradeType.Buy, symbolName, volume, targetPrice, label);
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips) => _algoMasterRobot.PlaceStopOrder(TradeType.Buy, symbolName, volume, targetPrice, label, stopLossPips, null);
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips) => _algoMasterRobot.PlaceStopOrder(TradeType.Buy, symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips);
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _algoMasterRobot.PlaceStopOrder(TradeType.Buy, symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration);
        public TradeResult PlaceBuyStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) => _algoMasterRobot.PlaceStopOrder(TradeType.Buy, symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration, "", hasTrailingStop);

        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label) => _algoMasterRobot.PlaceStopOrder(TradeType.Sell, symbolName, volume, targetPrice, label);
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips) => _algoMasterRobot.PlaceStopOrder(TradeType.Sell, symbolName, volume, targetPrice, label, stopLossPips, null);
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips) => _algoMasterRobot.PlaceStopOrder(TradeType.Sell, symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips);
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _algoMasterRobot.PlaceStopOrder(TradeType.Sell, symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration);
        public TradeResult PlaceSellStopOrder(string symbolName, double volume, double targetPrice, string label, double? stopLossPips, double? takeProfitPips, DateTime? expiration, bool hasTrailingStop) => _algoMasterRobot.PlaceStopOrder(TradeType.Sell, symbolName, volume, targetPrice, label, stopLossPips, takeProfitPips, expiration, "", hasTrailingStop);

        #endregion

        #region Modify Pending Orders

        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice) => _algoMasterRobot.ModifyPendingOrder(pendingOrder, targetPrice);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips) => _algoMasterRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLossPips, null);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips, double? takeProfitPips) => _algoMasterRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLossPips, takeProfitPips);
        public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLossPips, double? takeProfitPips, DateTime? expiration) => _algoMasterRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLossPips, takeProfitPips, expiration);

        #endregion

        #region Cancel Pending Orders

        public TradeResult CancelPendingOrder(PendingOrder pendingOrder) => _algoMasterRobot.CancelPendingOrder(pendingOrder);

        #endregion

        #endregion

        #region Positions

        #region Modify Positions

        public TradeResult ModifyPosition(Position position, double volume) => _algoMasterRobot.ModifyPosition(position, volume);
        public TradeResult ModifyPosition(Position position, double volume, double? stopLossPips) => _algoMasterRobot.ModifyPosition(position, volume, stopLossPips);
        public TradeResult ModifyPosition(Position position, double? stopLossPips, double? takeProfitPips) => _algoMasterRobot.ModifyPosition(position, stopLossPips, takeProfitPips);
        public TradeResult ModifyPosition(Position position, double? stopLossPips, double? takeProfitPips, bool hasTrailingStop) => _algoMasterRobot.ModifyPosition(position, stopLossPips, takeProfitPips, hasTrailingStop);

        #endregion

        #region Reverse Positions

        public TradeResult ReversePosition(Position position) => _algoMasterRobot.ReversePosition(position);
        public TradeResult ReversePosition(Position position, double volume) => _algoMasterRobot.ReversePosition(position, volume);

        #endregion

        #region Close Positions

        public TradeResult[] CloseAllPositions()
        {
            List<TradeResult> tradeResults = new List<TradeResult>();

            for(int i = 0; i < _algoMasterRobot.Positions.Count; i++)
            {
                tradeResults.Add(_algoMasterRobot.ClosePosition(_algoMasterRobot.Positions[i]));
            }

            return tradeResults.ToArray();
        }

        public TradeResult ClosePosition(Position position) => _algoMasterRobot.ClosePosition(position);
        public TradeResult ClosePosition(Position position, double volume) => _algoMasterRobot.ClosePosition(position, volume);

        #endregion

        #endregion

        #region Callbacks

        public void OnPositionOpened(PositionOpenedEventArgs args)
        {
            if (_unityRobots.Count > 0)
            {
                foreach (UnityRobot unityRobot in _unityRobots)
                {
                    if (args.Position.Label.Equals(unityRobot.Name))
                        unityRobot.OnPositionOpened(args);
                }
            }
        }
        public void OnPositionClosed(PositionClosedEventArgs args)
        {
            if (_unityRobots.Count > 0)
            {
                foreach (UnityRobot unityRobot in _unityRobots)
                {
                    if (args.Position.Label.Equals(unityRobot.Name))
                        unityRobot.OnPositionClosed(args);
                }
            }
        }
        public void OnPositionModified(PositionModifiedEventArgs args)
        {
            if (_unityRobots.Count > 0)
            {
                foreach (UnityRobot unityRobot in _unityRobots)
                {
                    if (args.Position.Label.Equals(unityRobot.Name))
                        unityRobot.OnPositionModified(args);
                }
            }
        }

        public void OnPendingOrderCreated(PendingOrderCreatedEventArgs args)
        {
            if (_unityRobots.Count > 0)
            {
                foreach (UnityRobot unityRobot in _unityRobots)
                {
                    if (args.PendingOrder.Label.Equals(unityRobot.Name))
                        unityRobot.OnPendingOrderCreated(args);
                }
            }
        }
        public void OnPendingOrderFilled(PendingOrderFilledEventArgs args)
        {
            if (_unityRobots.Count > 0)
            {
                foreach (UnityRobot unityRobot in _unityRobots)
                {
                    if (args.PendingOrder.Label.Equals(unityRobot.Name))
                        unityRobot.OnPendingOrderFilled(args);
                }
            }
        }
        public void OnPendingOrderModified(PendingOrderModifiedEventArgs args)
        {
            if (_unityRobots.Count > 0)
            {
                foreach (UnityRobot unityRobot in _unityRobots)
                {
                    if (args.PendingOrder.Label.Equals(unityRobot.Name))
                        unityRobot.OnPendingOrderModified(args);
                }
            }
        }
        public void OnPendingOrderCancelled(PendingOrderCancelledEventArgs args)
        {
            if (_unityRobots.Count > 0)
            {
                foreach (UnityRobot unityRobot in _unityRobots)
                {
                    if (args.PendingOrder.Label.Equals(unityRobot.Name))
                        unityRobot.OnPendingOrderCancelled(args);
                }
            }
        }

        #endregion

        public SPerformanceSnapshot[] RequestLogs()
        {
            List<SPerformanceSnapshot> performanceSnapshots = new();

            foreach(UnityRobot unityRobot in _unityRobots)
            {
                performanceSnapshots.Add(unityRobot.GetPerformanceSnapshot());
            }

            return performanceSnapshots.ToArray();
        } 

        #endregion

        #region Private Methods

        private void AddRobot(UnityRobot unityRobot) => _unityRobots.Add(unityRobot);
        private void RemoveRobot(UnityRobot unityRobot) => _unityRobots.Remove(unityRobot);

        private void SetupEvents()
        {
            _algoMasterRobot.Positions.Opened += OnPositionOpened;
            _algoMasterRobot.Positions.Closed += OnPositionClosed;
            _algoMasterRobot.Positions.Modified += OnPositionModified;

            _algoMasterRobot.PendingOrders.Created += OnPendingOrderCreated;
            _algoMasterRobot.PendingOrders.Filled += OnPendingOrderFilled;
            _algoMasterRobot.PendingOrders.Cancelled += OnPendingOrderCancelled;
            _algoMasterRobot.PendingOrders.Modified += OnPendingOrderModified;
        }

        #endregion

        #endregion
    }
}
