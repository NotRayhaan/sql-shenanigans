using Microsoft.EntityFrameworkCore;
using NorthwindTrades.Data;
using NorthwindTrades.Services.Orders;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IOrderService, OrderService>();
    builder.Services.AddDbContext<ApplicationDBContext>(options =>
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}