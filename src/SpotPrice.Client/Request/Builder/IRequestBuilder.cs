
namespace SpotPrice.Client.Request.Builder
{
    /// <summary>
    /// Base interface used to build requests.
    /// </summary>
    /// <typeparam name="TRequest">Type of request to build.</typeparam>
    public interface IRequestBuilder<TRequest>
    {
        /// <summary>
        /// Build the reuqest with the current input parameters.
        /// </summary>
        /// <returns>Built request.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when one of the required input parameters is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when one of the required input parameters is invalid.
        /// </exception>
        TRequest Build();
    }
}
