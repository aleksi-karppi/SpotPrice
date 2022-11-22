using System;

namespace SpotPrice.Error
{
    /// <summary>
    /// Base exception used by the <see cref="SpotPrice.ISpotPriceService"/>.
    /// </summary>
    public abstract class SpotPriceException
        : Exception
    {
        public SpotPriceException()
            : base()
        {
        }

        public SpotPriceException(string message)
            : base(message)
        {
        }

        public SpotPriceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
