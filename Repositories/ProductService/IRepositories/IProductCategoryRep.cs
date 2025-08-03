using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;

namespace ECommerceBackend.Repositories.ProductService.IRepositories
{
    public interface IProductCategoryRep : IGenericRepository<TblProductCategory>
    {
        Task <TblProductCategory> AddAsync(ProductCategoryDto newProductCategory);
        Task<bool> RemoveAsync(int id);
        Task<TblProductCategory> GetByIdAsync(int id);
        Task<IEnumerable<TblProduct>> GetProductsByCategoryAsync(int categoryId);
        Task<bool> UpdateAsync(int id, ProductCategoryDto dto);
    }
}
