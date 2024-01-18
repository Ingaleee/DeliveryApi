namespace DeliveryApi.Services.Responses;

public class GetServiceResponse<TModel> : AbstractServiceResponse
{
    public IEnumerable<TModel> Models { get; set; }

    public static GetServiceResponse<TModel> Success(IEnumerable<TModel> models) => new()
    {
        Models = models,
        Error = string.Empty,
        Processed = true
    };

    public static GetServiceResponse<TModel> Failed(string error) => new()
    {
        Models = new List<TModel>(),
        Error = string.Empty,
        Processed = false
    };
}