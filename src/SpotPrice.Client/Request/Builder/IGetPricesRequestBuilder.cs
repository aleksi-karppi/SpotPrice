
namespace SpotPrice.Client.Request.Builder
{
    /// <summary>
    /// Interface used to build <see cref="SpotPrice.Request.IGetPricesRequestBuilder"/> request.
    /// </summary>
    public interface IGetPricesRequestBuilder
        : IRequestBuilder<IGetPricesRequest>
    {
        /// <summary>
        /// Call to retrieve price listing for today.
        /// </summary>
        /// <returns>Builder instance.</returns>
        IGetPricesRequestBuilder ForToday();

        /// <summary>
        /// Call to retrieve price listing for tomorrow.
        /// </summary>
        /// <returns>Builder instance.</returns>
        IGetPricesRequestBuilder ForTomorrow();

        /// <summary>
        /// Call to retrieve price listing for both today and tomorrow.
        /// </summary>
        /// <returns>Builder instance.</returns>
        IGetPricesRequestBuilder ForTodayAndTomorrow();
    }
}
