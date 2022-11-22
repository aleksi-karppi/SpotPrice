using System;
using System.Collections.Generic;
using SpotPrice.Client.Extension;

namespace SpotPrice.Client.Request
{
    [Serializable]
    internal class CheckPriceRequest
        : ICheckPriceRequest
    {
        public int? Price { get; set; }

        public bool HasPrice
            => Price != null && Price.HasValue;

        public int? Rank { get; set; }

        public bool HasRank
            => Rank != null && Rank.HasValue;

        public IList<int> BoosterHours { get; }
            = new List<int>();

        public bool HasBoosterHours
            => BoosterHours.Count > 0;

        public CheckPriceRequest()
        {
        }

        public CheckPriceRequest(CheckPriceRequest other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            Price = other.Price;
            Rank = other.Rank;
            BoosterHours.AddRange(other.BoosterHours);
        }
    }
}
