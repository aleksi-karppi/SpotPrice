using System;

namespace SpotPrice.Error
{
    /// <summary>
    /// Exception thrown by the <see cref="SpotPrice.ISpotPriceService"/> when too many requests are made from the same IP address.
    /// </summary>
    public class SpotPriceOverloadedException
        : SpotPriceException
    {
        public SpotPriceOverloadedException()
            : base()
        {
        }

        public SpotPriceOverloadedException(string message)
            : base(message)
        {
        }

        public SpotPriceOverloadedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
