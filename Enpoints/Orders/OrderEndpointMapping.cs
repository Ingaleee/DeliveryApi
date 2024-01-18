using DeliveryApi.Services;

namespace DeliveryApi.Endpoints.Orders;

public static class OrderEndpointMapping
{
    public static CreateOrderData ToData(CreateOrderEPRequest epRequest) => new()
    {
        PickupDateUtc = epRequest.PickupDateUtc,
        RecipientAddress = epRequest.RecipientAddress,
        RecipientCity = epRequest.RecipientCity,
        SenderCity = epRequest.SenderCity,
        SenderAddress = epRequest.SenderAddress,
        Weight = epRequest.Weight
    };
}