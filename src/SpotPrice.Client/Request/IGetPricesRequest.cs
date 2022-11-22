using SpotPrice.Client.Model;

namespace SpotPrice.Client.Request
{
    /// <summary>
    /// Request used to retrieve price listing for today, tomorrow or both today and tomorrow combined.
    /// </summary>
    public interface IGetPricesRequest
    {
        /// <summary>
        /// Price range used to retrieve price listing.
        /// </summary>
        PriceRange Range { get; }

        /// <summary>
        /// Api path used to retrieve price listing.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Shorthand for checking if the <see cref="Range"/> property targets today.
        /// </summary>
        bool FetchToday { get; }

        /// <summary>
        /// Shorthand for checking if the <see cref="Range"/> property targets tomorrow.
        /// </summary>
        bool FetchTomorrow { get; }

        /// <summary>
        /// Shorthand for checking if the <see cref="Range"/> property targets both today and tomorrow.
        /// </summary>
        bool FetchTodayAndTomorrow { get; }
    }
}
