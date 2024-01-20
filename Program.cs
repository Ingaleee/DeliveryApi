using DeliveryApi.Domain;
using DeliveryApi.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerDocument();

}

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    var dbConnection = builder.Configuration.GetConnectionString("DbConnection");
    var sqlVersion = ServerVersion.AutoDetect(dbConnection);
    options.UseMySql(dbConnection, sqlVersion);
});
builder.Services.AddTransient<IDomainProvider, DomainProvider>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddCors();
builder.Services.AddControllers();

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi();
app.UseCors(_ => _.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

app.UseRouting();
app.UseEndpoints(b => b.MapControllers());

app.Run();
