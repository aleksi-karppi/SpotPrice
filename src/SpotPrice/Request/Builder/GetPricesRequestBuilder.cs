using SpotPrice.Model;

namespace SpotPrice.Request.Builder
{
    internal class GetPricesRequestBuilder
        : IGetPricesRequestBuilder
    {
        public GetPricesRequest Request { get; }
            = new GetPricesRequest();

        public IGetPricesRequestBuilder ForToday()
        {
            Request.Range |= PriceRange.Today;
            return this;
        }

        public IGetPricesRequestBuilder ForTodayAndTomorrow()
        {
            Request.Range |= PriceRange.Today;
            Request.Range |= PriceRange.Tomorrow;
            return this;
        }

        public IGetPricesRequestBuilder ForTomorrow()
        {
            Request.Range |= PriceRange.Tomorrow;
            return this;
        }

        public IGetPricesRequest Build()
        {
            return new GetPricesRequest(Request);
        }
    }
}
