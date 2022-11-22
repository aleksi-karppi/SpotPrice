using System;
using Newtonsoft.Json;

namespace SpotPrice.Model
{
    [Serializable]
    internal class PricePeriodModel : IPricePeriodModel
    {
        [JsonProperty("DateTimeStart")]
        public DateTime DateTimeStart { get; set; }

        [JsonProperty("DateTimeEnd")]
        public DateTime DateTimeEnd { get; set; }

        [JsonProperty("AveragePriceNoTax")]
        public double AveragePriceNoTax { get; set; }

        [JsonProperty("AveragePriceWithTax")]
        public double AveragePriceWithTax { get; set; }

        public PricePeriodModel()
        {
        }

        public PricePeriodModel(PricePeriodModel other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            DateTimeStart = other.DateTimeStart;
            DateTimeEnd = other.DateTimeEnd;
            AveragePriceNoTax = other.AveragePriceNoTax;
            AveragePriceWithTax = other.AveragePriceWithTax;
        }
    }
}
