using System.Collections.Generic;

namespace SpotPrice.Client.Request
{
    /// <summary>
    /// Request used to check if current price is within given parameters.
    /// </summary>
    public interface ICheckPriceRequest
    {
        /// <summary>
        /// Price in cents used to check against current the price.
        /// </summary>
        int? Price { get; }

        /// <summary>
        /// Shorthand for checking if the <see cref="Price"/> property is set.
        /// </summary>
        bool HasPrice { get; }

        /// <summary>
        /// Rank used to check against the current rank.
        /// </summary>
        int? Rank { get; }

        /// <summary>
        /// Shorthand for checking if the <see cref="Rank"/> property is set.
        /// </summary>
        bool HasRank { get; }

        /// <summary>
        /// Booster hours when the <see cref="Price"/> and <see cref="Rank"/> property are ignored.
        /// </summary>
        IList<int> BoosterHours { get; }

        /// <summary>
        /// Shorthand for checking if the <see cref="BoosterHours"/> property is empty or not.
        /// </summary>
        bool HasBoosterHours { get; }
    }
}
