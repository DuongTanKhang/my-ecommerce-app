using ECommerceBackend.Models;
using ECommerceBackend.Repositories.ProductService.IRepositories;

namespace ECommerceBackend.Repositories
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ECommerceMicroserviceContext _context;

        public IStockLogRepository StockLogRepository { get;private set; }

        public IProductsRep ProductsReppsitory { get; private set; }
        public UnitOfWork(ECommerceMicroserviceContext context, IStockLogRepository stockLogRepository,IProductsRep productsRep)
        {
            _context = context;
            StockLogRepository = stockLogRepository;
            ProductsReppsitory = productsRep;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
