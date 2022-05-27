namespace cAlgoUnityFramework.Data
{
    public struct STrades
    {
        #region Public Variables

        public int TotalTrades { get; private set; }
        public int WinningTrades { get; private set; }
        public int LosingTrades { get; private set; }

        public int MaxConsecutiveWinningTrades { get; private set; }
        public int MaxConsecutiveLosingTrades { get; private set; }

        #endregion

        #region Public Methods

        public STrades(int winningTrades, int losingTrades, int maxConsecutiveWinningTrades, int maxConsecutiveLosingTrades)
        {
            TotalTrades = winningTrades + losingTrades;
            WinningTrades = winningTrades;
            LosingTrades = losingTrades;

            MaxConsecutiveWinningTrades = maxConsecutiveWinningTrades;
            MaxConsecutiveLosingTrades = maxConsecutiveLosingTrades;
        }

        public override string ToString()
        {
            return $"Total Trades: {TotalTrades}\n" +
                $"Winning Trades: {WinningTrades}\n" +
                $"LosingTrades: {LosingTrades}\n\n" +
                $"Max Consecutive Winning Trades: {MaxConsecutiveWinningTrades}\n" +
                $"Max Consecutive Losing Trades: {MaxConsecutiveLosingTrades}\n";
        }

        #endregion  
    }
}
