using DeliveryApi.Services;

namespace DeliveryApi.Types
{
    public class Order : IHasId
    {
        public ulong Id { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddress { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddress { get; set; }
        public decimal Weight { get; set; }
        public DateTime PickupDate { get; set; }
    }
}
