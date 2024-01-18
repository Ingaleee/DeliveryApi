using DeliveryApi.Types;

namespace DeliveryApi.Services;

public static class OrderMapping
{
    public static OrderDto ToDto(Order order) => new()
    {
        Id = order.Id,
        PickupDateUtc = order.PickupDateUtc,
        RecipientAddress = order.RecipientAddress,
        RecipientCity = order.RecipientCity,
        SenderCity = order.SenderCity,
        SenderAddress = order.SenderAddress,
        Weight = order.Weight
    };

    public static Order FromCreateData(CreateOrderData data) => new()
    {
        PickupDateUtc = data.PickupDateUtc,
        RecipientAddress = data.RecipientAddress,
        RecipientCity = data.RecipientCity,
        SenderCity = data.SenderCity,
        SenderAddress = data.SenderAddress,
        Weight = data.Weight
    };
}