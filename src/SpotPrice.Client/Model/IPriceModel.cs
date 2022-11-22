using System;

namespace SpotPrice.Client.Model
{
    /// <summary>
    /// Class used to model price.
    /// </summary>
    public interface IPriceModel
    {
        /// <summary>
        /// Price rank.
        /// </summary>
        int Rank { get; }

        /// <summary>
        /// Price date time.
        /// </summary>
        DateTime DateTime { get; }

        /// <summary>
        /// Price without taxes.
        /// </summary>
        double PriceNoTax { get; }

        /// <summary>
        /// Price with taxes.
        /// </summary>
        double PriceWithTax { get; }
    }
}
