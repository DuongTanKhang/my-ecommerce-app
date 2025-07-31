using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;

namespace ECommerceBackend.Repositories.ProductService.IRepositories
{
    public interface IProductsRep
    {
        Task<IEnumerable<TblProduct>> GetAllAsync();
        Task<TblProduct?> GetByIdAsync(int id);
        Task<TblProduct> AddAsync(TblProduct product);
        Task<bool> UpdateAsync(int id, UpdateProductDto product);
    }
}
