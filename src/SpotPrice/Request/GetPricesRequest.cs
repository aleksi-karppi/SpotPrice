using System;
using SpotPrice.Model;

namespace SpotPrice.Request
{
    [Serializable]
    internal class GetPricesRequest
        : IGetPricesRequest
    {
        public PriceRange Range { get; set; }

        public string Path
            => FetchTodayAndTomorrow
                ? "TodayAndDayForward"
                : FetchToday
                    ? "Today"
                    : "DayForward";

        public bool FetchToday
            => Range.HasFlag(PriceRange.Today);

        public bool FetchTomorrow
            => Range.HasFlag(PriceRange.Tomorrow);

        public bool FetchTodayAndTomorrow
            => Range.HasFlag(PriceRange.Today) &&
               Range.HasFlag(PriceRange.Tomorrow);

        public GetPricesRequest()
        {
        }

        public GetPricesRequest(GetPricesRequest other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            Range = other.Range;
        }
    }
}
