using System.Collections.Generic;

namespace SpotPrice.Client.Request.Builder
{
    /// <summary>
    /// Interface used to build <see cref="SpotPrice.Request.ICheckPriceRequest"/> request.
    /// </summary>
    public interface ICheckPriceRequestBuilder
        : IRequestBuilder<ICheckPriceRequest>
    {
        /// <summary>
        /// Set the price in cents used to check against current the price.
        /// </summary>
        /// <param name="price">The price in cents used to check against current the price.</param>
        /// <returns>Builder instance.</returns>
        ICheckPriceRequestBuilder UnderPrice(
            int price);

        /// <summary>
        /// Set the rank used to check against the current rank.
        /// </summary>
        /// <param name="rank">The rank used to check against the current rank.</param>
        /// <returns>Builder instance.</returns>
        ICheckPriceRequestBuilder UnderRank(
            int rank);

        /// <summary>
        /// Set the booster hours when the price and rank are ignored.
        /// </summary>
        /// <param name="boosterHours">The booster hours when the price and rank are ignored</param>
        /// <returns>Builder instance.</returns>
        ICheckPriceRequestBuilder WithBoosterHours(
            IEnumerable<int> boosterHours);
    }
}
