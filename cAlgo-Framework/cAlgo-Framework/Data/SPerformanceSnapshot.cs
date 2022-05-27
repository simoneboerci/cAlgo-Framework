namespace cAlgoUnityFramework.Data
{
    public struct SPerformanceSnapshot
    {
        #region Public Variables

        public double NetProfit { get; private set; }

        public double ProfitFactor { get; private set; }

        public SDrawdown Drawdown { get; private set; }

        public STrades Trades { get; private set; }

        #endregion

        #region Public Methods

        public SPerformanceSnapshot(double netProfit, double profitFactor, SDrawdown drawdown, STrades trades)
        {
            NetProfit = netProfit;
            ProfitFactor = profitFactor;
            Drawdown = drawdown;
            Trades = trades;
        }

        public override string ToString()
        {
            return $"Net Profit: {NetProfit}\n\n" +
                $"Profit Factor: {ProfitFactor}\n\n" +
                $"{Drawdown}" +
                $"{Trades}";
        }

        #endregion
    }
}
