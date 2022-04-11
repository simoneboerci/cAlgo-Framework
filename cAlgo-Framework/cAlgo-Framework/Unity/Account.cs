using cAlgo.API;

namespace cAlgoUnityFramework.Unity
{
    public class Account
    {
        #region Variables

        #region Public Variables

        public double Balance { get; private set; }
        public double Equity { get; private set; }

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

        public void UpdateBalance(double netProfit) => Balance += netProfit;

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
        }

        #endregion

        #region Events

        public void OnPositionOpened(PositionOpenedEventArgs args) => Positions.Add(args.Position);
        public void OnPositionClosed(PositionClosedEventArgs args)
        {
            Positions.Remove(args.Position);
            History.Add(args.Position);

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

        #endregion

        #endregion
    }
}
