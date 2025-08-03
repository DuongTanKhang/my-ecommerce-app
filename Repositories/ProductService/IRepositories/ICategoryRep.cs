using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;

namespace ECommerceBackend.Repositories.ProductService.IRepositories
{
    public interface ICategoryRep : IGenericRepository<TblCategory>
    {
        Task<IEnumerable<TblCategory?>> GetAllAsync();

        Task<TblCategory?> GetByIdAsync(int id);

        Task <TblCategory> AddAsync(CategoryDto category);

        Task<bool> UpdateAsync(int id, CategoryDto categoryDto);

        Task<bool> DeleteAsync(int id);
    }
}
