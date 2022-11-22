using System;
using System.Collections.Generic;
using SpotPrice.Error;
using SpotPrice.Extension;

namespace SpotPrice.Request.Builder
{
    internal class GetCheapestPriceRequestBuilder
        : IGetCheapestPriceRequestBuilder
    {
        public GetCheapestPriceRequest Request { get; }
            = new GetCheapestPriceRequest();

        public IGetCheapestPriceRequestBuilder ForPeriod(int hours)
        {
            if (hours < 1 || hours > 12)
                throw new ArgumentException(
                    "Cheapest period must be between 1 and 12 hours",
                    nameof(hours));

            Request.Hours = hours;
            return this;
        }

        public IGetCheapestPriceRequestBuilder WithBoosterHours(
            IEnumerable<int> boosterHours)
        {
            if (boosterHours is null)
                throw new ArgumentNullException(
                    nameof(boosterHours));

            Request.BoosterHours.AddRange(boosterHours);
            return this;
        }

        public IGetCheapestPriceRequest Build()
        {
            if (Request.Hours < 1 || Request.Hours > 12)
                throw new ArgumentException(
                    "Cheapest period must be between 1 and 12 hours");

            return new GetCheapestPriceRequest(Request);
        }
    }
}
