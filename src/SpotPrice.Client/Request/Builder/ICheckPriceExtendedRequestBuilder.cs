using System.Collections.Generic;

namespace SpotPrice.Client.Request.Builder
{
    /// <summary>
    /// Interface used to build <see cref="SpotPrice.Request.ICheckPriceExtendedRequest"/> request.
    /// </summary>
    public interface ICheckPriceExtendedRequestBuilder
        : IRequestBuilder<ICheckPriceExtendedRequest>
    {
        /// <summary>
        /// Set the postal code used to check the price.
        /// </summary>
        /// <param name="postalCode">The postal code used to check the price.</param>
        /// <returns>Builder instance.</returns>
        ICheckPriceExtendedRequestBuilder InPostalCode(
            string postalCode);

        /// <summary>
        /// Set the rank used when forecasted temperature is 0°C.
        /// </summary>
        /// <param name="rankAtZeroDegrees">The rank used when forecasted temperature is 0°C.</param>
        /// <returns>Builder instance.</returns>
        ICheckPriceExtendedRequestBuilder WithRankAtZeroDegrees(
            int rankAtZeroDegrees);

        /// <summary>
        /// Set the rank percentage change (1-20) when temperature changes by 1°C.
        /// </summary>
        /// <param name="rankAdjusterPercentage">Tthe rank percentage change (1-20) when temperature changes by 1°C.</param>
        /// <returns>Builder instance.</returns>
        ICheckPriceExtendedRequestBuilder WithRankAdjusterPercentage(
            int rankAdjusterPercentage);

        /// <summary>
        /// Set the minimum rank under which the calculated rank can't go.
        /// </summary>
        /// <param name="minimumRank">The minimum rank under which the calculated rank can't go.</param>
        /// <returns>Builder instance</returns>
        ICheckPriceExtendedRequestBuilder WithMinimumRank(
            int minimumRank);

        /// <summary>
        /// Set the taxable price per kWh in cents which is always accepted.
        /// </summary>
        /// <param name="priceAlwaysAllowed">The taxable price per kWh in cents which is always accepted.</param>
        /// <returns>Builder instance.</returns>
        ICheckPriceExtendedRequestBuilder WithPriceAlwaysAllowed(
            int priceAlwaysAllowed);

        /// <summary>
        /// Set the booster hours when the price and rank are ignored.
        /// </summary>
        /// <param name="boosterHours">The booster hours when the price and rank are ignored.</param>
        /// <returns>Builder instance.</returns>
        ICheckPriceExtendedRequestBuilder WithBoosterHours(
            IEnumerable<int> boosterHours);

        /// <summary>
        /// Call to enable debug mode.
        /// In debug mode the price check returns additional debug information in <see cref="SpotPrice.Model.IPriceCheckModel.Message"/> property.
        /// </summary>
        /// <returns>Builder instance.</returns>
        ICheckPriceExtendedRequestBuilder WithDebugMode();
    }
}
