using System;

namespace SpotPrice.Client.Model
{
    [Serializable]
    internal class PriceCheckModel
        : IPriceCheckModel
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public bool HasMessage
            => !string.IsNullOrEmpty(Message);

        public PriceCheckModel()
        {
        }

        public PriceCheckModel(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public PriceCheckModel(PriceCheckModel other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            Success = other.Success;
            Message = other.Message;
        }
    }
}
