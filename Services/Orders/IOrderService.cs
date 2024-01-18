using DeliveryApi.Services.Responses;
using DeliveryApi.Types;

namespace DeliveryApi.Services;

public interface IOrderService
{
    Task<FindServiceResponse<OrderDto>> FindAsync(ulong id);
    Task<CreateServiceResponse> CreateAsync(CreateOrderData data);
    Task<GetServiceResponse<OrderDto>> Get();
}