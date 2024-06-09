
using Microsoft.EntityFrameworkCore;
using NorthwindTrades.Data;
using NorthwindTrades.Dtos.Order;
using NorthwindTrades.Interfaces;
using NorthwindTrades.Models;

namespace NorthwindTrades.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDBContext _context;
    public OrderRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateAsync(Order orderModel)
    {
        await _context.Orders.AddAsync(orderModel);
        await _context.SaveChangesAsync();
        return orderModel;

    }

    public async Task<Order?> DeleteAsync(Guid id)
    {
        Order? orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.OrderID == id);
        if (orderModel == null) return null;

        _context.Orders.Remove(orderModel);
        await _context.SaveChangesAsync();
        return orderModel;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task<Order?> UpdateAsync(Guid id, UpdateOrderRequestDto orderDto)
    {
        Order? orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.OrderID == id);
        if (orderModel == null) return null;
        orderModel.CustomerID = orderDto.CustomerID;
        orderModel.EmployeeID = orderDto.EmployeeID;
        orderModel.OrderDate = orderDto.OrderDate;
        orderModel.ModifiedDate = DateTime.UtcNow;
        orderModel.ShipperID = orderDto.ShipperID;

        await _context.SaveChangesAsync();
        return orderModel;
    }
}