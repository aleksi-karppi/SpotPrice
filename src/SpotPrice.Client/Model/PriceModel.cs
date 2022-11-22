using System;
using Newtonsoft.Json;

namespace SpotPrice.Client.Model
{
    [Serializable]
    internal class PriceModel : IPriceModel
    {
        [JsonProperty("Rank")]
        public int Rank { get; set; }

        [JsonProperty("DateTime")]
        public DateTime DateTime { get; set; }

        [JsonProperty("PriceNoTax")]
        public double PriceNoTax { get; set; }

        [JsonProperty("PriceWithTax")]
        public double PriceWithTax { get; set; }

        public PriceModel()
        {
        }

        public PriceModel(PriceModel other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            Rank = other.Rank;
            DateTime = other.DateTime;
            PriceNoTax = other.PriceNoTax;
            PriceWithTax = other.PriceWithTax;
        }
    }
}
