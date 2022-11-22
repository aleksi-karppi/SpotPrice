using System.Collections.Generic;

namespace SpotPrice.Request.Builder
{
    /// <summary>
    /// Interface used to build <see cref="SpotPrice.Request.IGetCheapestPriceRequest"/> request.
    /// </summary>
    public interface IGetCheapestPriceRequestBuilder
        : IRequestBuilder<IGetCheapestPriceRequest>
    {
        /// <summary>
        /// Set the hour for which to retrieve the cheapest price.
        /// </summary>
        /// <param name="hours">The hour for which to retrieve the cheapest price</param>
        /// <returns>Builder instance.</returns>
        IGetCheapestPriceRequestBuilder ForPeriod(
            int hours);

        /// <summary>
        /// Set the booster hours when the price is always considered to be cheapest.
        /// </summary>
        /// <param name="boosterHours">the booster hours when the price is always considered to be cheapest.</param>
        /// <returns>Builder instance.</returns>
        IGetCheapestPriceRequestBuilder WithBoosterHours(
            IEnumerable<int> boosterHours);
    }
}
