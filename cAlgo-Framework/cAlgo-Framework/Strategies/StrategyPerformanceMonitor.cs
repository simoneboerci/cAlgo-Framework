using cAlgo.API;

namespace cAlgoUnityFramework.Strategies
{
    public class StrategyPerformanceMonitor
    {
        #region Variables

        #region Public Variables

        public int Trades { get { return Wins + Losses; } }

        public int Wins { get { return LongWins + ShortWins; } }
        public int Losses { get { return LongLosses + ShortLosses; } }

        public double WinRate 
        {
            get
            {
                if (Trades > 0) return Wins / Trades * 100.0;
                else return 100.0;
            }
        }

        public int Longs { get { return LongWins + LongLosses; } }
        public int Shorts { get { return ShortWins + ShortLosses; } }

        public double LongRate
        {
            get
            {
                if (Trades > 0) return Longs / Trades * 100.0;
                else return 100.0;
            }
        }

        public int LongWins { get; private set; }
        public int LongLosses { get; private set; }

        public double LongWinRate
        {
            get
            {
                if (Longs > 0) return LongWins / Longs * 100.0;
                else return 100.0;
            }
        }

        public int ShortWins { get; private set; }
        public int ShortLosses { get; private set; }

        public double ShortWinRate
        {
            get
            {
                if (Shorts > 0) return ShortWins / Shorts * 100.0;
                else return 100.0;
            }
        }

        public int Stops { get { return LongStops + ShortStops; } }
        public int TakeProfits { get { return LongTakeProfits + ShortTakeProfits; } }

        public double TakeProfitRate
        {
            get
            {
                if (Trades > 0) return TakeProfits / Trades * 100.0;
                else return 100.0;
            }
        }

        public int LongStops { get; private set; }
        public int LongTakeProfits { get; private set; }

        public double LongTakeProfitRate
        {
            get
            {
                if (Longs > 0) return LongTakeProfits / Longs * 100.0;
                else return 100.0;
            }
        }

        public int ShortStops { get; private set; }
        public int ShortTakeProfits { get; private set; }

        public double ShortTakeProfitRate
        {
            get
            {
                if (Shorts > 0) return ShortTakeProfits / Shorts * 100.0;
                else return 100.0;
            }
        }

        public int MaxConsecutiveWins { get; private set; }
        public int MaxConsecutiveLosses { get; private set; }

        public int CurrentConsecutiveWins { get; private set; }
        public int CurrentConsecutiveLosses { get; private set; }

        #endregion

        #region Protected Variables

        protected readonly StrategyBase _strategy;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public StrategyPerformanceMonitor(StrategyBase strategy)
        {
            _strategy = strategy;

            _strategy.OnWin += OnWin;
            _strategy.OnLoss += OnLoss;
            _strategy.OnTakeProfit += OnTakeProfit;
            _strategy.OnStopLoss += OnStopLoss;
        }

        #endregion

        #region Private Methods

        private void OnWin(Position position)
        {
            if (position.TradeType == TradeType.Buy) LongWins++;
            else if (position.TradeType == TradeType.Sell) ShortWins++;

            CurrentConsecutiveLosses = 0;
            CurrentConsecutiveWins++;

            if(CurrentConsecutiveWins > MaxConsecutiveWins)
                MaxConsecutiveWins = CurrentConsecutiveWins;
        }
        private void OnLoss(Position position)
        {
            if (position.TradeType == TradeType.Buy) LongLosses++;
            else if (position.TradeType == TradeType.Sell) ShortLosses++;

            CurrentConsecutiveWins = 0;
            CurrentConsecutiveLosses++;

            if(CurrentConsecutiveLosses > MaxConsecutiveLosses)
                MaxConsecutiveLosses = CurrentConsecutiveLosses;
        }

        private void OnTakeProfit(Position position)
        {
            if (position.TradeType == TradeType.Buy) LongTakeProfits++;
            else if (position.TradeType == TradeType.Sell) ShortTakeProfits++;
        }
        private void OnStopLoss(Position position)
        {
            if (position.TradeType == TradeType.Buy) LongStops++;
            else if (position.TradeType == TradeType.Sell) ShortStops++;
        }

        #endregion

        #endregion
    }
}
