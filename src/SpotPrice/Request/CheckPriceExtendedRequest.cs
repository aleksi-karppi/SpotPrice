using System;
using System.Collections.Generic;
using SpotPrice.Extension;

namespace SpotPrice.Request
{
    [Serializable]
    internal class CheckPriceExtendedRequest
        : ICheckPriceExtendedRequest
    {
        public int? RankAtZeroDegrees { get; set; }

        public bool HasRankAtZeroDegrees
            => RankAtZeroDegrees != null &&
               RankAtZeroDegrees.HasValue;

        public int? RankAdjusterPercentage { get; set; }

        public bool HasRankAdjusterPercentage
            => RankAdjusterPercentage != null &&
               RankAdjusterPercentage.HasValue;

        public int? MinimumRank { get; set; }

        public bool HasMinimumRank
            => MinimumRank != null &&
               MinimumRank.HasValue;

        public int? PriceAlwaysAllowed { get; set; }

        public bool HasPriceAlwaysAllowed
            => PriceAlwaysAllowed != null &&
               PriceAlwaysAllowed.HasValue;

        public string PostalCode { get; set; }

        public bool HasPostalCode
            => !string.IsNullOrWhiteSpace(PostalCode);

        public IList<int> BoosterHours { get; }
            = new List<int>();

        public bool DebugMode { get; set; }

        public CheckPriceExtendedRequest()
        {
        }

        public CheckPriceExtendedRequest(CheckPriceExtendedRequest other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            RankAtZeroDegrees = other.RankAtZeroDegrees;
            RankAdjusterPercentage = other.RankAdjusterPercentage;
            MinimumRank = other.MinimumRank;
            PriceAlwaysAllowed = other.PriceAlwaysAllowed;
            PostalCode = other.PostalCode;
            BoosterHours.AddRange(other.BoosterHours);
            DebugMode = other.DebugMode;
        }
    }
}
