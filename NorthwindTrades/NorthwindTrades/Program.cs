using NorthwindTrades.Services.Orders;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IOrderService, OrderService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    // app.UseAuthorization();
    app.MapControllers();
    app.Run();
}