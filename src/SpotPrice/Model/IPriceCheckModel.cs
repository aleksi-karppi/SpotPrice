
namespace SpotPrice.Model
{
    /// <summary>
    /// Class used to model price check.
    /// </summary>
    public interface IPriceCheckModel
    {
        /// <summary>
        /// Price check success.
        /// True when price check was under the given parameters, false otherwise
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// Price check message.
        /// The message can contain additional debug information when requested in debug mode.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Shorthand for checking if the <see cref="Message"/> property is set.
        /// </summary>
        bool HasMessage { get; }
    }
}
