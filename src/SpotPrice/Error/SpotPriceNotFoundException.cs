using System;

namespace SpotPrice.Error
{
    /// <summary>
    /// Exception thrown by the <see cref="SpotPrice.ISpotPriceService"/> when requested data is not found.
    /// </summary>
    public class SpotPriceNotFoundException
        : SpotPriceException
    {
        public SpotPriceNotFoundException()
            : base()
        {
        }

        public SpotPriceNotFoundException(string message)
            : base(message)
        {
        }

        public SpotPriceNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
