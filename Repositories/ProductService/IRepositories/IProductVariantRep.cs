using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;

namespace ECommerceBackend.Repositories.ProductService.IRepositories
{
    public interface IProductVariantRep : IGenericRepository<TblProductVariant>
    {
        Task<TblProductVariant> AddAsync(ProductVariantDto newProductVariant);
        Task<bool> RemoveAsync(int id);
        Task<TblProductVariant?> GetByIdAsync(int id);
        Task<IEnumerable<TblProductVariant?>> GetVariantsByProductIdAsync(int productId);
        Task<bool> UpdateAsync(int id, ProductVariantDto dto);
    }
}
