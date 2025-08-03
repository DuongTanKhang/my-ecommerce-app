using ECommerceBackend.Repositories.ProductService.IRepositories;

namespace ECommerceBackend.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IStockLogRepository StockLogRepository { get; }
        IProductsRep ProductsReppsitory { get; }
        Task<int> CompleteAsync();
    }
}
