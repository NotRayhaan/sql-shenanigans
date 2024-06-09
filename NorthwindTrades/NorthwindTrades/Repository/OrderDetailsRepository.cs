using Microsoft.EntityFrameworkCore;
using NorthwindTrades.Data;
using NorthwindTrades.Dtos.OrderDetails;
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
        throw new NotImplementedException();
    }

    public async Task<OrderDetails?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<OrderDetails>> GetAllAsync()
    {
        return await _context.OrderDetails.ToListAsync();
    }

    public async Task<OrderDetails?> GetByIdAsync(int id)
    {
        return await _context.OrderDetails.FindAsync(id);
    }

    public async Task<OrderDetails?> UpdateAsync(int id, UpdateOrderDetailsRequestDto ordeDetailsrDto)
    {
        throw new NotImplementedException();
    }
}