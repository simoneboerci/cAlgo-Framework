using cAlgo.API;

namespace cAlgoUnityFramework.Strategies
{
    internal interface IStrategy
    {
        #region Public Methods

        public void Execute();

        #region Orders

        #region Execute Market Orders

        public TradeResult ExecuteBuyOrder();
        public TradeResult ExecuteSellOrder();

        #endregion

        #region Execute Buy Range Orders

        public TradeResult ExecuteBuyRangeOrder(double marketRangePips, double basePrice);
        public TradeResult ExecuteSellRangeOrder(double marketRangePips, double basePrice);

        #endregion

        #region Place Limit Orders

        public TradeResult PlaceBuyLimitOrder(double targetPrice);
        public TradeResult PlaceBuyLimitOrder(double targetPrice, DateTime? expiration);

        public TradeResult PlaceSellLimitOrder(double targetPrice);
        public TradeResult PlaceSellLimitOrder(double targetPrice, DateTime? expiration);

        #endregion

        #region Place Stop-Limit Orders

        public TradeResult PlaceBuyStopLimitOrder(double targetPrice, double stopLimitRangePips);
        public TradeResult PlaceBuyStopLimitOrder(double targetPrice, double stopLimitRangePips, DateTime? expiration);

        public TradeResult PlaceSellStopLimitOrder(double targetPrice, double stopLimitRangePips);
        public TradeResult PlaceSellStopLimitOrder(double targetPrice, double stopLimitRangePips, DateTime? expiration);

        #endregion

        #region Place Stop Orders

        public TradeResult PlaceBuyStopOrder(double targetPrice);
        public TradeResult PlaceBuyStopOrder(double targetPrice, DateTime? expiration);

        public TradeResult PlaceSellStopOrder(double targetPrice);
        public TradeResult PlaceSellStopOrder(double targetPrice, DateTime? expiration);

        #endregion

        #endregion

        #endregion
    }
}
