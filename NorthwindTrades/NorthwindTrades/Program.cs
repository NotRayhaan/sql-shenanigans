using Microsoft.EntityFrameworkCore;
using NorthwindTrades.Data;
using NorthwindTrades.Interfaces;
using NorthwindTrades.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["ConnectionString"];
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<ApplicationDBContext>(options =>
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });
    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
    // prevent object cycles
    builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}