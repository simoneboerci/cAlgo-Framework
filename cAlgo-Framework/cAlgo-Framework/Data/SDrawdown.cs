namespace cAlgoUnityFramework.Data
{
    public struct SDrawdown
    {
        #region Public Variables

        public double MaxBalanceDrawdown { get; private set; }
        public double MaxEquityDrawdown { get; private set; }

        #endregion

        #region Public Methods

        public SDrawdown(double maxBalanceDrawdown, double maxEquityDrawdown)
        {
            MaxBalanceDrawdown = maxBalanceDrawdown;
            MaxEquityDrawdown = maxEquityDrawdown;
        }

        public override string ToString()
        {
            return $"Max Balance Drawdown: {MaxBalanceDrawdown}\n" +
                $"Max Equity Drawdown: {MaxEquityDrawdown}\n";
        }

        #endregion
    }
}
