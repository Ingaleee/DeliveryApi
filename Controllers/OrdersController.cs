using DeliveryApi.Endpoints.Orders;
using DeliveryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : Controller
{
    private readonly IOrderService _orders;
    
    public OrdersController(IOrderService order)
    {
        _orders = order;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var response = await _orders.Get();
        
        if (!response.Processed)
            return BadRequest(response.Error);
        
        return Ok(response.Models);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(ulong id)
    {
        var response = await _orders.FindAsync(id);
        
        if (!response.Processed)
            return BadRequest(response.Error);
        
        return Ok(response.Model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]CreateOrderEPRequest request)
    {
        var data = OrderEndpointMapping.ToData(request);
        var response = await _orders.CreateAsync(data);
        
        if (!response.Processed)
            return BadRequest(response.Error);
        
        return Ok(response.NewId);
    }
}