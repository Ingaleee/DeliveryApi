namespace DeliveryApi.Types
{
    public class OrderErrorCodes
    {
        public const string NOT_FOUND = "OrderNotFound";
        public const string INVALID_DATA = "OrderInvalidData";
        public const string INVALID_SENDER_CITY = "OrderInvalidSenderCity";
        public const string INVALID_SENDER_ADDRESS = "OrderInvalidSenderAddress";
        public const string INVALID_RECEPIENT_CITY = "OrderInvalidRecepientCity";
        public const string INVALID_RECEPIENT_ADDRESS = "OrderInvalidRecepientAddress";
        public const string INVALID_PICKUP_DATE = "OrderInvalidPickupDate";
        public const string ZERO_WEIGHT = "OrderZeroWeight";
    }
}
