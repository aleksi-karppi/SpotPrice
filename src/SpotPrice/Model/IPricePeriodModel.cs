using System;

namespace SpotPrice.Model
{
    /// <summary>
    /// Class used to model price period.
    /// </summary>
    public interface IPricePeriodModel
    {
        /// <summary>
        /// Price period start date time.
        /// </summary>
        DateTime DateTimeStart { get; }

        /// <summary>
        /// Price period end date time.
        /// </summary>
        DateTime DateTimeEnd { get; }

        /// <summary>
        /// Average price without taxes.
        /// </summary>
        double AveragePriceNoTax { get; }

        /// <summary>
        /// Average price with taxes.
        /// </summary>
        double AveragePriceWithTax { get; }
    }
}
