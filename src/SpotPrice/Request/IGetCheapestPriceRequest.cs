using System.Collections.Generic;

namespace SpotPrice.Request
{
    /// <summary>
    /// Request used to retrieve cheapest known price period.
    /// </summary>
    public interface IGetCheapestPriceRequest
    {
        /// <summary>
        /// Hour for which to retrieve the cheapest price.
        /// </summary>
        int Hours { get; }

        /// <summary>
        /// Booster hours when the price is always considered to be cheapest.
        /// </summary>
        IList<int> BoosterHours { get; }
    }
}
