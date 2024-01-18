using DeliveryApi.Services.Responses;
using DeliveryApi.Types;

namespace DeliveryApi.Services;

public class OrderService : IOrderService
{
    private readonly IDomainProvider _domain;
    
    public OrderService(IDomainProvider domain)
    {
        _domain = domain;
    }

    public async Task<FindServiceResponse<OrderDto>> FindAsync(ulong id)
    {
        try
        {
            var order = await _domain.GetByIdAsync<Order>(id);
            if (order == null)
            {
                return FindServiceResponse<OrderDto>.Failed(OrderErrorCodes.NOT_FOUND);
            }

            var dto = OrderMapping.ToDto(order);
            return FindServiceResponse<OrderDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return FindServiceResponse<OrderDto>.Failed(ex.Message);
        }
    }

    public async Task<CreateServiceResponse> CreateAsync(CreateOrderData data)
    {
        try
        {
            // TODO: Use validators
            if (data == null)
            {
                return CreateServiceResponse.Failed(OrderErrorCodes.INVALID_DATA);
            }

            if (data.Weight == 0M)
            {
                return CreateServiceResponse.Failed(OrderErrorCodes.ZERO_WEIGHT);
            }

            var invalidSenderAddress = string.IsNullOrWhiteSpace(data.SenderAddress);
            if (invalidSenderAddress)
            {
                return CreateServiceResponse.Failed(OrderErrorCodes.INVALID_SENDER_ADDRESS);
            }
            
            var invalidRecipientCity = string.IsNullOrWhiteSpace(data.RecipientCity);
            if (invalidRecipientCity)
            {
                return CreateServiceResponse.Failed(OrderErrorCodes.INVALID_RECEPIENT_CITY);
            }
            
            var invalidRecipientAddress = string.IsNullOrWhiteSpace(data.RecipientAddress);
            if (invalidRecipientAddress)
            {
                return CreateServiceResponse.Failed(OrderErrorCodes.INVALID_RECEPIENT_ADDRESS);
            }
            
            var invalidSenderCity = string.IsNullOrWhiteSpace(data.SenderCity);
            if (invalidSenderCity)
            {
                return CreateServiceResponse.Failed(OrderErrorCodes.INVALID_SENDER_CITY);
            }

            var invalidPickupDate = DateTime.UtcNow > data.PickupDateUtc;
            if (invalidPickupDate)
            {
                return CreateServiceResponse.Failed(OrderErrorCodes.INVALID_PICKUP_DATE);
            }

            var order = OrderMapping.FromCreateData(data);
            var newId = await _domain.AddAsync(order);
            return CreateServiceResponse.Success(newId);
        }
        catch (Exception ex)
        {
            return CreateServiceResponse.Failed(ex.Message);
        }
    }

    public async Task<GetServiceResponse<OrderDto>> Get()
    {
        try
        {
            var orders = await _domain.GetAllAsync<Order>();
            var dtos = orders.Select(OrderMapping.ToDto);
            return GetServiceResponse<OrderDto>.Success(dtos);
        }
        catch (Exception ex)
        {
            return GetServiceResponse<OrderDto>.Failed(ex.Message);
        }
    }
}