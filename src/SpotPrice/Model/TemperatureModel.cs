using System;
using Newtonsoft.Json;

namespace SpotPrice.Model
{
    internal class TemperatureModel : ITemperatureModel
    {
        [JsonProperty("TimeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("Temperature")]
        public double Temperature { get; set; }

        [JsonProperty("CloudinessPercentage")]
        public double CloudinessPercentage { get; set; }

        [JsonProperty("PrecipitationAmountMm")]
        public double PrecipitationAmountMm { get; set; }

        public TemperatureModel()
        {
        }

        public TemperatureModel(TemperatureModel other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            TimeStamp = other.TimeStamp;
            Temperature = other.Temperature;
            CloudinessPercentage = other.CloudinessPercentage;
            PrecipitationAmountMm = other.PrecipitationAmountMm;
        }
    }
}
