namespace DeliveryApi.Endpoints.Orders;

public class CreateOrderEPRequest
{
    public string SenderCity { get; set; }
    public string SenderAddress { get; set; }
    public string RecipientCity { get; set; }
    public string RecipientAddress { get; set; }
    public decimal Weight { get; set; }
    public DateTime PickupDateUtc { get; set; }
}