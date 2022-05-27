using cAlgo.API;

using cAlgoUnityFramework.Unity;

namespace cAlgoUnityFramework.cAlgo
{
    public abstract class AlgoMasterRobot : Robot
    {
        #region Variables

        #region Public Variables

        public double BalanceDrawdown { get; private set; }
        public double EquityDrawdown { get; private set; }

        #endregion

        #region Protected Variables

        protected readonly UnityMasterRobot _unityMasterRobot;

        #endregion

        #region Private Variables

        private double _balancePeak = 0, _maxBalanceDrawdown = 0;
        private double _equityPeak = 0, _maxEquityDrawdown = 0;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public AlgoMasterRobot() => _unityMasterRobot = new UnityMasterRobot(this);

        #endregion

        #region Protected Methods

        protected abstract void Main();

        protected virtual void Update() { }

        #region cAlgo Life Cycle

        protected sealed override void OnStart()
        {
            Positions.Closed += UpdateBalanceDrawdown;

            Main();

            _unityMasterRobot.Start();
        }

        protected sealed override void OnBar()
        {
            OnUpdate();

            _unityMasterRobot.FixedUpdate();
        }
        protected sealed override void OnTick()
        {
            _unityMasterRobot.Update();
            _unityMasterRobot.LateUpdate();
        }

        protected sealed override void OnStop()
        {
            _unityMasterRobot.Stop();
        }
        protected sealed override void OnError(Error error)
        {
            Print(error);

            _unityMasterRobot.Stop();
        }

        #endregion

        #endregion

        #region Private Methods

        private void OnUpdate()
        {
            UpdateEquityDrawdown();

            Update();
        }

        private void UpdateEquityDrawdown()
        {
            EquityDrawdown = (_equityPeak - Account.Equity) / _equityPeak * 100.0;

            if (Account.Equity > _equityPeak) _equityPeak = Account.Equity;

            if (EquityDrawdown > _maxEquityDrawdown) _maxEquityDrawdown = EquityDrawdown;
        }

        private void UpdateBalanceDrawdown(PositionClosedEventArgs args)
        {
            BalanceDrawdown = (_balancePeak - Account.Balance) / _balancePeak * 100.0;

            if(args.Position.NetProfit > 0)
            {
                if (Account.Balance > _balancePeak) _balancePeak = Account.Balance;
            }
            else if(args.Position.NetProfit < 0)
            {
                if (BalanceDrawdown > _maxBalanceDrawdown) _maxBalanceDrawdown = BalanceDrawdown;
            }
        }

        #endregion

        #endregion
    }
}
