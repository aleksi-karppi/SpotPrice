using System;
using System.Collections.Generic;
using SpotPrice.Client.Extension;

namespace SpotPrice.Client.Request.Builder
{
    internal class CheckPriceExtendedRequestBuilder
        : ICheckPriceExtendedRequestBuilder
    {
        public CheckPriceExtendedRequest Request { get; }
            = new CheckPriceExtendedRequest();

        public ICheckPriceExtendedRequestBuilder InPostalCode(
            string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode?.Trim() ?? null))
                throw new ArgumentNullException(nameof(postalCode));
            if (!int.TryParse(postalCode.Trim(), out _))
                throw new ArgumentException(
                    "Postal code must be a numeric string", nameof(postalCode));

            Request.PostalCode = postalCode.Trim();
            return this;
        }

        public ICheckPriceExtendedRequestBuilder WithRankAtZeroDegrees(
            int rankAtZeroDegrees)
        {
            Request.RankAtZeroDegrees = rankAtZeroDegrees;
            return this;
        }

        public ICheckPriceExtendedRequestBuilder WithRankAdjusterPercentage(
            int rankAdjusterPercentage)
        {
            if (rankAdjusterPercentage < 0 || rankAdjusterPercentage > 20)
                throw new ArgumentException(
                    "Rank adjuster percentage must be between 0 and 20",
                    nameof(rankAdjusterPercentage));

            Request.RankAdjusterPercentage = rankAdjusterPercentage;
            return this;
        }

        public ICheckPriceExtendedRequestBuilder WithMinimumRank(
            int minimumRank)
        {
            Request.MinimumRank = minimumRank;
            return this;
        }

        public ICheckPriceExtendedRequestBuilder WithPriceAlwaysAllowed(
            int priceAlwaysAllowed)
        {
            if (priceAlwaysAllowed < 0)
                throw new ArgumentException(
                    "Always allowed price must be a positive number",
                    nameof(priceAlwaysAllowed));

            Request.PriceAlwaysAllowed = priceAlwaysAllowed;
            return this;
        }

        public ICheckPriceExtendedRequestBuilder WithBoosterHours(
            IEnumerable<int> boosterHours)
        {
            if (boosterHours is null)
                throw new ArgumentNullException(nameof(boosterHours));

            Request.BoosterHours.AddRange(boosterHours);
            return this;
        }

        public ICheckPriceExtendedRequestBuilder WithDebugMode()
        {
            Request.DebugMode = true;
            return this;
        }

        public ICheckPriceExtendedRequest Build()
        {
            if (!Request.HasRankAtZeroDegrees)
                throw new ArgumentException(
                    "Rank at zero degress must be set for a price check");
            if (!Request.HasRankAdjusterPercentage)
                throw new ArgumentException(
                    "Rank adjuster percentage must be set for a price check");
            if (!Request.HasMinimumRank)
                throw new ArgumentException(
                    "Minimum rank must be set for price check");
            if (!Request.HasPriceAlwaysAllowed)
                throw new ArgumentException(
                    "Price always allowed must be set for price check");
            if (!Request.HasPostalCode)
                throw new ArgumentException(
                    "Postal code must be set for price check");

            return new CheckPriceExtendedRequest(Request);
        }
    }
}
