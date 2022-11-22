using System;

namespace SpotPrice.Request.Builder
{
    internal class GetTemperatureRequestBuilder
        : IGetTemperatureRequestBuilder
    {
        public GetTemperatureRequest Request { get; }
            = new GetTemperatureRequest();

        public IGetTemperatureRequestBuilder InPostalCode(
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

        public IGetTemperatureRequest Build()
        {
            if (string.IsNullOrWhiteSpace(Request.PostalCode?.Trim() ?? null))
                throw new ArgumentNullException(nameof(Request.PostalCode));

            return new GetTemperatureRequest(Request);
        }
    }
}
