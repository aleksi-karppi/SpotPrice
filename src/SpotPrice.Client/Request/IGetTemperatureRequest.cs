
namespace SpotPrice.Client.Request
{
    /// <summary>
    /// Request used to retrieve temperature listing for the requested area.
    /// </summary>
    public interface IGetTemperatureRequest
    {
        /// <summary>
        /// Postal code used to retrieve temperatures.
        /// </summary>
        string PostalCode { get; }
    }
}
