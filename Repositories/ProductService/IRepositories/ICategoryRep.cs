using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;

namespace ECommerceBackend.Repositories.ProductService.IRepositories
{
    public interface ICategoryRep
    {
        Task<IEnumerable<TblCategory?>> GetAllAsync();
        Task<TblCategory?> GetByIdAsync(int id);
        Task <TblCategory> AddAsync(TblCategory category);
        Task<bool> UpdateAsync(int id, UpdateCategoryDto categoryDto);
    }
}
