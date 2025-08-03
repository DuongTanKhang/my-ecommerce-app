using ECommerceBackend.Models.ProductService;

namespace ECommerceBackend.Repositories.ProductService.IRepositories
{
    public interface IStockLogRepository : IGenericRepository<TblStockLog>
    {
        Task<IEnumerable<TblStockLog>> GetByProductIdAsync(int productId);
    }
}
