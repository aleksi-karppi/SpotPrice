using System;
using System.Collections.Generic;
using SpotPrice.Client.Extension;

namespace SpotPrice.Client.Request
{
    [Serializable]
    internal class GetCheapestPriceRequest
        : IGetCheapestPriceRequest
    {
        public int Hours { get; set; }

        public IList<int> BoosterHours { get; }
            = new List<int>();

        public GetCheapestPriceRequest()
        {
        }

        public GetCheapestPriceRequest(GetCheapestPriceRequest other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            Hours = other.Hours;
            BoosterHours.AddRange(other.BoosterHours);
        }
    }
}
