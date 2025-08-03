using ECommerceBackend.Models;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBackend.Repositories.ProductService.Rep
{
    public class StockLogRepository : GenericRepository<TblStockLog>, IStockLogRepository
    {
        private readonly ECommerceMicroserviceContext _context;
        public StockLogRepository(ECommerceMicroserviceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TblStockLog>> GetByProductIdAsync(int productId)
        {
            return await _context.TblStockLogs
                .Where(log => log.ProductId == productId)
                .OrderByDescending(log => log.CreatedDate)
                .ToListAsync();
        }
    }
}
