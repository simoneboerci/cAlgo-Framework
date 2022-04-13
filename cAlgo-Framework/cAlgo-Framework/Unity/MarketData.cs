using cAlgo.API;
using cAlgo.API.Internals;

namespace cAlgoUnityFramework.Unity
{
    public class MarketData
    {
        #region Public Variables

        public DateTime ServerTimeInUTC;
        public DayOfWeek CurrentDay { get { return ServerTimeInUTC.DayOfWeek; } }

        public Symbol Symbol { get; private set; }
        public string SymbolName { get { return Symbol.Name; } }
        public TimeFrame TimeFrame { get; private set; }
        public Bars Bars { get; private set; }

        #region Get Candles

        public Bar FirstCandle { get { return Bars.Last(1); } }
        public Bar SecondCandle { get { return Bars.Last(2); } }
        public Bar ThirdCandle { get { return Bars.Last(3); } }
        public Bar FourthCandle { get { return Bars.Last(4); } }
        public Bar FifthCandle { get { return Bars.Last(5); } }

        #endregion

        #endregion

        #region Public Methods

        public MarketData(Symbol symbol, TimeFrame timeFrame, Bars bars)
        {
            Symbol = symbol;
            TimeFrame = timeFrame;
            Bars = bars;
        }

        #endregion
    }
}
