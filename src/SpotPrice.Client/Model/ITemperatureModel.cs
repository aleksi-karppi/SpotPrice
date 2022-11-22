using System;

namespace SpotPrice.Client.Model
{
    /// <summary>
    /// Class used to model temperature.
    /// </summary>
    public interface ITemperatureModel
    {
        /// <summary>
        /// Temperature date time.
        /// </summary>
        DateTime TimeStamp { get; }

        /// <summary>
        /// Temperature amount.
        /// </summary>
        double Temperature { get; }

        /// <summary>
        /// Cloudiness percentage.
        /// </summary>
        double CloudinessPercentage { get; }

        /// <summary>
        /// Precipitation amount.
        /// </summary>
        double PrecipitationAmountMm { get; }
    }
}
