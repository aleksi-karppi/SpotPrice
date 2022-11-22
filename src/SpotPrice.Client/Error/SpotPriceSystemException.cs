using System;

namespace SpotPrice.Client.Error
{
    /// <summary>
    /// Exception thrown by the <see cref="SpotPrice.ISpotPriceService"/> when system error occurred during the request.
    /// </summary>
    public class SpotPriceSystemException
        : SpotPriceException
    {
        public SpotPriceSystemException()
            : base()
        {
        }

        public SpotPriceSystemException(string message)
            : base(message)
        {
        }

        public SpotPriceSystemException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
