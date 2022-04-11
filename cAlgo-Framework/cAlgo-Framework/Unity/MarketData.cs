using cAlgo.API;
using cAlgo.API.Internals;

namespace cAlgoUnityFramework.Unity
{
    public class MarketData
    {
        #region Public Variables

        public DateTime ServerTimeInUTC;

        public Symbol Symbol { get; private set; }
        public TimeFrame TimeFrame { get; private set; }
        public Bars Bars { get; private set; }

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
