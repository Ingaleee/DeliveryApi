using DeliveryApi.Domain;
using DeliveryApi.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    var dbConnection = builder.Configuration.GetConnectionString("DbConnection");
    var sqlVersion = ServerVersion.AutoDetect(dbConnection);
    options.UseMySql(dbConnection, sqlVersion);
});
builder.Services.AddTransient<IDomainProvider, DomainProvider>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Run();
