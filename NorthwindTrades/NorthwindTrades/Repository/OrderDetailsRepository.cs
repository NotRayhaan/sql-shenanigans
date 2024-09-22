using Microsoft.EntityFrameworkCore;
using NorthwindTrades.Data;
using NorthwindTrades.Interfaces;
using NorthwindTrades.Models;

namespace NorthwindTrades.Repository;

public class OrderDetailsRepository : IOrderDetailsRepository
{
    private readonly ApplicationDBContext _context;
    public OrderDetailsRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<OrderDetails> CreateAsync(OrderDetails orderDetailsModel)
    {
        await _context.OrderDetails.AddAsync(orderDetailsModel);
        await _context.SaveChangesAsync();
        return orderDetailsModel;
    }

    public async Task<OrderDetails?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<OrderDetails>> GetAllAsync()
    {
        return await _context.OrderDetails.Include(c => c.Product).ToListAsync();
    }

    public async Task<OrderDetails?> GetByIdAsync(int id)
    {
        return await _context.OrderDetails.Include(c => c.Product).FirstOrDefaultAsync(i => i.OrderDetailID == id);
    }

    public async Task<OrderDetails?> UpdateAsync(int id, OrderDetails orderDetailsModel)
    {
        var existingOrderDetails = await _context.OrderDetails.FindAsync(id);

        if (existingOrderDetails == null)
        {
            return null;
        }

        existingOrderDetails.Quantity = orderDetailsModel.Quantity;
        existingOrderDetails.Product = orderDetailsModel.Product;
        existingOrderDetails.ProductID = orderDetailsModel.ProductID;

        await _context.SaveChangesAsync();

        return existingOrderDetails;
    }
}