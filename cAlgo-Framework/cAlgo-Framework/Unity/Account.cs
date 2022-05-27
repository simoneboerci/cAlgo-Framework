using cAlgo.API;

namespace cAlgoUnityFramework.Unity
{
    public class Account
    {
        #region Variables

        #region Public Variables

        public double NetProfit { get; private set; }

        public double Balance { get; private set; }
        public double Equity { get; private set; }

        public double BalanceDrawdown { get; private set; }
        public double EquityDrawdown { get; private set; }

        public double BalancePeak { get; private set; }
        public double EquityPeak { get; private set; }

        public double MaxBalanceDrawdown { get; private set; }
        public double MaxEquityDrawdown { get; private set; }

        public List<Position> History { get; private set; }

        public List<Position> Positions { get; private set; }
        public List<PendingOrder> PendingOrders { get; private set; }

        #endregion

        #region Private Variables

        private readonly UnityRobot _unityRobot;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public Account(UnityRobot unityRobot, double startingBalance)
        {
            _unityRobot = unityRobot;

            Balance = startingBalance;
            Equity = Balance;

            History = new();

            Positions = new();
            PendingOrders = new();

            SetupEvents();
        }

        #region Update Balance / Equity

        public void UpdateBalance(double netProfit)
        { 
            Balance += netProfit;

            UpdateBalanceDrawdown();
        }

        public void UpdateEquity()
        {
            Equity = Balance;

            if(Positions.Count > 0)
            {
                foreach(Position position in Positions)
                {
                    Equity += position.NetProfit;
                }
            }

            UpdateBalanceDrawdown();
        }

        #endregion

        #region Events

        public void OnPositionOpened(PositionOpenedEventArgs args) => Positions.Add(args.Position);
        public void OnPositionClosed(PositionClosedEventArgs args)
        {
            Positions.Remove(args.Position);
            History.Add(args.Position);

            NetProfit += args.Position.NetProfit;

            UpdateBalance(args.Position.NetProfit);
        }

        public void OnPendingOrderCreated(PendingOrderCreatedEventArgs args) => PendingOrders.Add(args.PendingOrder);
        public void OnPendingOrderCancelled(PendingOrderCancelledEventArgs args) => PendingOrders.Remove(args.PendingOrder);
        public void OnPendingOrderFilled(PendingOrderFilledEventArgs args) => PendingOrders.Remove(args.PendingOrder);

        #endregion

        #endregion

        #region Private Methods

        private void SetupEvents()
        {
            _unityRobot.PositionOpened += OnPositionOpened;
            _unityRobot.PositionClosed += OnPositionClosed;

            _unityRobot.PendingOrderCreated += OnPendingOrderCreated;
            _unityRobot.PendingOrderCancelled += OnPendingOrderCancelled;
            _unityRobot.PendingOrderFilled += OnPendingOrderFilled;
        }

        #region Update Drawdown

        private void UpdateBalanceDrawdown()
        {
            BalanceDrawdown = (BalancePeak - Balance) / BalancePeak * 100.0;

            if (Balance > BalancePeak) BalancePeak = Balance;

            if (BalanceDrawdown > MaxBalanceDrawdown) MaxBalanceDrawdown = BalanceDrawdown;
        }

        private void UpdateEquityDrawdown()
        {
            EquityDrawdown = (EquityPeak - Equity) / EquityPeak * 100.0;

            if (Equity > EquityPeak) EquityPeak = Equity;

            if (EquityDrawdown > MaxEquityDrawdown) MaxEquityDrawdown = EquityDrawdown;
        }

        #endregion

        #endregion

        #endregion
    }
}
