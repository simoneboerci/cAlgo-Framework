using cAlgo.API;

namespace cAlgoUnityFramework.Tools
{
    public static class MarketScanner
    {
        #region Public Methods

        #region Get Ranges

        public static double GetCandleFullRange(Bar bar) => Math.Abs(bar.High - bar.Low);
        public static double GetCandleRange(Bar bar) => Math.Abs(bar.Close - bar.Open);

        public static double GetCandleBodyToRangeRatio(Bar bar) => GetCandleRange(bar) / GetCandleFullRange(bar);

        #endregion

        #region Checks

        #region Bullish / Bearish

        #region Is Bullish / Bearish

        public static bool IsBullish(Bar bar) => bar.Close > bar.Open;
        public static bool IsBearish(Bar bar) => bar.Close < bar.Open;

        #endregion

        #region Are Bullish / Bearish

        public static bool AreCandlesBullish(Bar bar, Bar bar2) => IsBullish(bar) && IsBullish(bar2);
        public static bool AreCandlesBearish(Bar bar, Bar bar2) => IsBearish(bar) && IsBearish(bar2);

        public static bool AreCandlesBullish(Bar bar, Bar bar2, Bar bar3) => IsBullish(bar) && IsBullish(bar2) && IsBullish(bar3);
        public static bool AreCandlesBearish(Bar bar, Bar bar2, Bar bar3) => IsBearish(bar) && IsBearish(bar2) && IsBearish(bar3);

        public static bool AreCandlesBullish(Bar bar, Bar bar2, Bar bar3, Bar bar4) => IsBullish(bar) && IsBullish(bar2) && IsBullish(bar3) && IsBullish(bar4);
        public static bool AreCandlesBearish(Bar bar, Bar bar2, Bar bar3, Bar bar4) => IsBearish(bar) && IsBearish(bar2) && IsBearish(bar3) && IsBearish(bar4);

        public static bool AreCandlesBullish(Bar bar, Bar bar2, Bar bar3, Bar bar4, Bar bar5) => IsBullish(bar) && IsBullish(bar2) && IsBullish(bar3) && IsBullish(bar4) && IsBullish(bar5);
        public static bool AreCandlesBearish(Bar bar, Bar bar2, Bar bar3, Bar bar4, Bar bar5) => IsBearish(bar) && IsBearish(bar2) && IsBearish(bar3) && IsBearish(bar4) && IsBearish(bar5);

        #endregion

        #endregion

        #region Patterns

        #region Indecision

        public static bool IsIndecisionCandle(Bar bar) => GetCandleBodyToRangeRatio(bar) < 0.5;

        #endregion

        #region Marubozu

        public static bool BullishMarubozu(Bar bar) => IsBullish(bar) && bar.High <= bar.Close && bar.Low >= bar.Open;
        public static bool BearishMarubozu(Bar bar) => IsBearish(bar) && bar.High <= bar.Open && bar.Low >= bar.Close;

        public static bool BullishClosingMarubozu(Bar bar) => IsBullish(bar) && bar.High <= bar.Close && bar.Low < bar.Open;
        public static bool BearishClosingMarubozu(Bar bar) => IsBearish(bar) && bar.High <= bar.Open && bar.Low < bar.Close;

        public static bool BullishOpeningMarubozu(Bar bar) => IsBullish(bar) && bar.High > bar.Close && bar.Low <= bar.Open;
        public static bool BearishOpeningMarubozu(Bar bar) => IsBearish(bar) && bar.High <= bar.Open && bar.Low < bar.Close;

        #endregion

        #region Spinning Top

        public static bool BullishSpinningTop(Bar bar) => IsBullish(bar) && IsIndecisionCandle(bar);
        public static bool BearishSpinningTop(Bar bar) => IsBearish(bar) && IsIndecisionCandle(bar);

        #endregion

        #region Doji

        public static bool IsDoji(Bar bar) => GetCandleBodyToRangeRatio(bar) < 0.05;

        public static bool IsBullishDoji(Bar bar) => IsBullish(bar) && IsDoji(bar);
        public static bool IsBearishDoji(Bar bar) => IsBearish(bar) && IsDoji(bar);

        #endregion

        #region Engulfing

        public static bool IsBullishEngulfing(Bar bar, Bar previousBar) => IsBullish(bar) && IsBearish(previousBar) && bar.Close > previousBar.High && bar.Open < previousBar.Low;
        public static bool IsBearishEngulfing(Bar bar, Bar previousBar) => IsBearish(bar) && IsBullish(previousBar) && bar.Close < previousBar.Low && bar.Open > previousBar.High;

        #endregion

        #region Harami

        public static bool IsBullishHarami(Bar bar, Bar previousBar) => IsBullish(bar) && IsBearish(bar) && bar.High < previousBar.Open && bar.Low > previousBar.Close;
        public static bool IsBearishHarami(Bar bar, Bar previousBar) => IsBearish(bar) && IsBullish(bar) && bar.High < previousBar.Close && bar.Low > previousBar.Open;

        #endregion

        #region Kicker

        public static bool IsBullishKicker(Bar bar, Bar previousBar) => IsBullish(bar) && IsBearish(previousBar) && !IsIndecisionCandle(bar) && !IsIndecisionCandle(previousBar);
        public static bool IsBearishKicker(Bar bar, Bar previousBar) => IsBearish(bar) && IsBearish(previousBar) && !IsIndecisionCandle(bar) && !IsIndecisionCandle(previousBar);

        #endregion

        #region Three White Soldiers / Black Crows

        public static bool IsThreeWhiteSoldiers(Bar bar1, Bar bar2, Bar bar3) => IsBullish(bar1) && IsBullish(bar2) && IsBullish(bar3) && bar2.Open < bar1.Close && bar3.Open < bar2.Close;
        public static bool IsThreeBlackCrows(Bar bar1, Bar bar2, Bar bar3) => IsBearish(bar1) && IsBearish(bar2) && IsBearish(bar3) && bar2.Open > bar1.Close && bar3.Open > bar2.Close;

        #endregion

        #region Belthold

        public static bool IsBullishBelthold(Bar bar) => IsBullish(bar) && bar.Low <= bar.Open && bar.High > bar.Close;
        public static bool IsBearishBelthold(Bar bar) => IsBearish(bar) && bar.High <= bar.Open && bar.Low < bar.Close;

        #endregion

        #region Breakaway

        public static bool IsBullishBreakaway(Bar bar1, Bar bar2, Bar bar3, Bar bar4, Bar bar5)
        {
            return IsBullish(bar1) && IsBearish(bar2) && IsBearish(bar3) && IsBearish(bar4) && IsBearish(bar5) &&
                bar4.Open < bar5.Close && bar1.Close >= bar5.Close;
        }
        public static bool IsBearishBreakaway(Bar bar1, Bar bar2, Bar bar3, Bar bar4, Bar bar5)
        {
            return IsBearish(bar1) && IsBullish(bar2) && IsBullish(bar3) && IsBullish(bar4) && IsBullish(bar5) &&
                bar4.Open > bar5.Close && bar1.Close <= bar5.Close;
        }

        #endregion

        #region Rising / Falling Three

        public static bool IsRisingThree(Bar bar1, Bar bar2, Bar bar3, Bar bar4, Bar bar5)
        {
            return IsBullish(bar1) && IsBearish(bar2) && IsBearish(bar3) && IsBearish(bar4) && IsBullish(bar5) &&
                bar2.Close > bar5.Open && bar1.Close > bar4.High;
        }
        public static bool IsFallingThree(Bar bar1, Bar bar2, Bar bar3, Bar bar4, Bar bar5)
        {
            return IsBearish(bar1) && IsBullish(bar2) && IsBullish(bar3) && IsBullish(bar4) && IsBearish(bar5) &&
                bar2.Close < bar5.Open && bar1.Close < bar4.Low;
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }
}
