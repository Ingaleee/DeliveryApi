namespace DeliveryApi.Services.Responses;

public class CreateServiceResponse : AbstractServiceResponse
{
    public ulong? NewId { get; set; }

    public static CreateServiceResponse Success(ulong newId) => new()
    {
        Error = string.Empty,
        Processed = true,
        NewId = newId
    };

    public static CreateServiceResponse Failed(string error) => new()
    {
        Error = error,
        Processed = false,
        NewId = null
    };
}