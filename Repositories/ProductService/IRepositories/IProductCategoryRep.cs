using ECommerceBackend.Models.ProductService;

namespace ECommerceBackend.Repositories.ProductService.IRepositories
{
    public interface IProductCategoryRep
    {
        Task <bool> Addsync(int productId,int categoryId);
        Task<bool> Removesync(int productId, int categoryId);
        Task<IEnumerable<TblCategory>> GetProductsByCategorySync(int categoryId);
    }
}
