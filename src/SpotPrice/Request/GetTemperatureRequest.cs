using System;

namespace SpotPrice.Request
{
    [Serializable]
    internal class GetTemperatureRequest
        : IGetTemperatureRequest
    {
        public string PostalCode { get; set; }

        public GetTemperatureRequest()
        {
        }

        public GetTemperatureRequest(GetTemperatureRequest other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            PostalCode = other.PostalCode;
        }
    }
}
