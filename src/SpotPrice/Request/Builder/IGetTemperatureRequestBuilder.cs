
namespace SpotPrice.Request.Builder
{
    /// <summary>
    /// Interface used to build <see cref="SpotPrice.Request.IGetTemperatureRequest"/> request.
    /// </summary>
    public interface IGetTemperatureRequestBuilder
        : IRequestBuilder<IGetTemperatureRequest>
    {
        /// <summary>
        /// Set the postal code used to retrieve temperatures.
        /// </summary>
        /// <param name="postalCode">The postal code used to retrieve temperatures.</param>
        /// <returns>Builder instance.</returns>
        IGetTemperatureRequestBuilder InPostalCode(
            string postalCode);
    }
}
