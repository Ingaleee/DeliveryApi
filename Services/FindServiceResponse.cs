namespace DeliveryApi.Services.Responses;

public class FindServiceResponse<TModel> : AbstractServiceResponse
{
    public TModel Model { get; set; }

    public static FindServiceResponse<TModel> Success(TModel model) => new()
    {
        Model = model,
        Error = string.Empty,
        Processed = true,
    };

    public static FindServiceResponse<TModel> Failed(string error) => new()
    {
        Model = default,
        Error = error,
        Processed = false
    };
}