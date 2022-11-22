using System;
using System.Collections.Generic;
using SpotPrice.Client.Extension;

namespace SpotPrice.Client.Request.Builder
{
    internal class CheckPriceRequestBuilder
        : ICheckPriceRequestBuilder
    {
        public CheckPriceRequest Request { get; }
            = new CheckPriceRequest();

        public ICheckPriceRequestBuilder UnderPrice(int price)
        {
            if (price <= 0)
                throw new ArgumentException(
                    "Price must be a positive number",
                    nameof(price));

            Request.Price = price;
            return this;
        }

        public ICheckPriceRequestBuilder UnderRank(int rank)
        {
            if (rank <= 0)
                throw new ArgumentException(
                    "Rank must be a positive number",
                    nameof(rank));

            Request.Rank = rank;
            return this;
        }

        public ICheckPriceRequestBuilder WithBoosterHours(
            IEnumerable<int> boosterHours)
        {
            if (boosterHours is null)
                throw new ArgumentNullException(
                    nameof(boosterHours));

            Request.BoosterHours.AddRange(boosterHours);
            return this;
        }

        public ICheckPriceRequest Build()
        {
            if (!Request.HasPrice && !Request.HasRank)
                throw new ArgumentException(
                    "Price or rank must be set for price request");

            if (!Request.HasRank && Request.HasBoosterHours)
                throw new ArgumentException(
                    "Booster hours can only be used with rank request");

            return new CheckPriceRequest(Request);
        }
    }
}
