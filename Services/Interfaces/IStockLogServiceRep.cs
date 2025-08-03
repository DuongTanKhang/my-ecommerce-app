using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.Enum;

namespace ECommerceBackend.Repositories.ProductService.IRepositories
{
    public interface IStockLogServiceRep
    {
        Task LogAsync(int productId, int changeAmount, StockChangeReason reason, string? reference = null);
        Task<IEnumerable<TblStockLog?>> GetAllLogsAsync();
        Task<IEnumerable<TblStockLog>> GetLogsByProductAsync(int productId);
    }

}
