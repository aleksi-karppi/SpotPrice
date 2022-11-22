using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotPrice.Model;
using SpotPrice.Request.Builder;

namespace SpotPrice
{
    /// <summary>
    /// Service used to query https://api.spot-hinta.fi API.
    /// </summary>
    public interface ISpotPriceService
    {
        /// <summary>
        /// Retrieve rank for the past hour.
        /// </summary>
        /// <returns>The rank for the past hour.</returns>
        /// <exception cref="SpotPrice.Error.SpotPriceNotFoundException">
        /// Thrown when requested data is not found.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceOverloadedException">
        /// Thrown when too many requests are made from the same IP address.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceSystemException">
        /// Thrown when system error occurred during the request.
        /// </exception>
        Task<int> GetRankAsync();

        /// <summary>
        /// Retrieve price for the past hour.
        /// </summary>
        /// <returns>The price for the past hour.</returns>
        /// <exception cref="SpotPrice.Error.SpotPriceNotFoundException">
        /// Thrown when requested data is not found.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceOverloadedException">
        /// Thrown when too many requests are made from the same IP address.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceSystemException">
        /// Thrown when system error occurred during the request.
        /// </exception>
        Task<IPriceModel> GetPriceAsync();

        /// <summary>
        /// Retrieve price listing for today, tomorrow or both today and tomorrow combined.
        /// </summary>
        /// <param name="builder">Request builder lambda.</param>
        /// <returns>The requested price listing.</returns>
        /// <exception cref="SpotPrice.Error.SpotPriceNotFoundException">
        /// Thrown when requested data is not found.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceOverloadedException">
        /// Thrown when too many requests are made from the same IP address.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceSystemException">
        /// Thrown when system error occurred during the request.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when request builder lambda is null.
        /// </exception>
        Task<IList<IPriceModel>> GetPricesAsync(
            Action<IGetPricesRequestBuilder> builder);

        /// <summary>
        /// Retrieve cheapest known price period.
        /// </summary>
        /// <param name="builder">Request builder lambda.</param>
        /// <returns>Cheapest known price period.</returns>
        /// <exception cref="SpotPrice.Error.SpotPriceNotFoundException">
        /// Thrown when requested data is not found.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceOverloadedException">
        /// Thrown when too many requests are made from the same IP address.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceSystemException">
        /// Thrown when system error occurred during the request.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when request builder lambda is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when request can't be built from request builder due to bad input data.
        /// </exception>
        Task<IPricePeriodModel> GetCheapestPeriodAsync(
            Action<IGetCheapestPriceRequestBuilder> builder);

        /// <summary>
        /// Retrieve temperature listing for the requested area.
        /// </summary>
        /// <param name="builder">Request builder lambda.</param>
        /// <returns>The requested temperature listing.</returns>
        /// <exception cref="SpotPrice.Error.SpotPriceNotFoundException">
        /// Thrown when requested data is not found.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceOverloadedException">
        /// Thrown when too many requests are made from the same IP address.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceSystemException">
        /// Thrown when system error occurred during the request.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when request builder lambda is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when request can't be built from request builder due to bad input data.
        /// </exception>
        Task<IList<ITemperatureModel>> GetTemperaturesAsync(
            Action<IGetTemperatureRequestBuilder> builder);

        /// <summary>
        /// Check if current price is within given parameters.
        /// </summary>
        /// <param name="builder">Request builder lambda.</param>
        /// <returns>Price check model where the Success field is true when the current price is within the given parameters.</returns>
        /// <exception cref="SpotPrice.Error.SpotPriceNotFoundException">
        /// Thrown when requested data is not found.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceOverloadedException">
        /// Thrown when too many requests are made from the same IP address.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceSystemException">
        /// Thrown when system error occurred during the request.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when request builder lambda is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when request can't be built from request builder due to bad input data.
        /// </exception>
        Task<IPriceCheckModel> CheckPriceAsync(
            Action<ICheckPriceRequestBuilder> builder);

        /// <summary>
        /// Check if current price is within given parameters.
        /// </summary>
        /// <param name="builder">Request builder lambda.</param>
        /// <returns>Price check model where the Success field is true when the current price is within the given parameters.</returns>
        /// <exception cref="SpotPrice.Error.SpotPriceNotFoundException">
        /// Thrown when requested data is not found.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceOverloadedException">
        /// Thrown when too many requests are made from the same IP address.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceSystemException">
        /// Thrown when system error occurred during the request.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when request builder lambda is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when request can't be built from request builder due to bad input data.
        /// </exception>
        Task<IPriceCheckModel> CheckPriceExtendedAsync(
            Action<ICheckPriceExtendedRequestBuilder> builder);

        /// <summary>
        /// Check if the current price is within the cheapest price period.
        /// </summary>
        /// <param name="builder">Request builder lambda.</param>
        /// <returns>True current price is within the cheapest price period, false otherwise.</returns>
        /// <exception cref="SpotPrice.Error.SpotPriceNotFoundException">
        /// Thrown when requested data is not found.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceOverloadedException">
        /// Thrown when too many requests are made from the same IP address.
        /// </exception>
        /// <exception cref="SpotPrice.Error.SpotPriceSystemException">
        /// Thrown when system error occurred during the request.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when request builder lambda is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when request can't be built from request builder due to bad input data.
        /// </exception>
        Task<bool> CheckCheapestPeriodAsync(
            Action<IGetCheapestPriceRequestBuilder> builder);
    }
}
