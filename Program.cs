using DeliveryApi.Domain;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    var dbConnection = builder.Configuration.GetConnectionString("DbConnection");
    var sqlVersion = ServerVersion.AutoDetect(dbConnection);
    options.UseMySql(dbConnection, sqlVersion);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Run();
