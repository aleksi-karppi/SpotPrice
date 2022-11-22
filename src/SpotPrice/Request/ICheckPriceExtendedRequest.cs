using System.Collections.Generic;

namespace SpotPrice.Request
{
    /// <summary>
    /// Request used to check if current price is within given parameters.
    /// </summary>
    public interface ICheckPriceExtendedRequest
    {
        /// <summary>
        /// Rank used when forecasted temperature is 0°C.
        /// </summary>
        int? RankAtZeroDegrees { get; }

        /// <summary>
        /// Rank percentage change (1-20) when temperature changes by 1°C.
        /// </summary>
        int? RankAdjusterPercentage { get; }

        /// <summary>
        /// Minimum rank under which the calculated rank can't go.
        /// </summary>
        int? MinimumRank { get; }

        /// <summary>
        /// Taxable price per kWh in cents which is always accepted.
        /// </summary>
        int? PriceAlwaysAllowed { get; }

        /// <summary>
        /// Postal code used to check the price.
        /// </summary>
        string PostalCode { get; }

        /// <summary>
        /// Booster hours when the price and rank are ignored.
        /// </summary>
        IList<int> BoosterHours { get; }

        /// <summary>
        /// Price check returns additional debug information in <see cref="SpotPrice.Model.IPriceCheckModel.Message"/> property when debug mode is enabled.
        /// </summary>
        bool DebugMode { get; }
    }
}
