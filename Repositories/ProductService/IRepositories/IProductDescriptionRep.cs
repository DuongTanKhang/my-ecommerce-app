using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;

namespace ECommerceBackend.Repositories.ProductService.IRepositories
{
    public interface IProductDescriptionRep
    {
        Task <TblProductDescription> AddSync(int productId, UpdateProductDescriptionDto dto);
        Task<TblProductDescription?> GetByIdAsync(int descriptionId);
        Task<IEnumerable<TblProductDescription?>> GetByProductIdSync(int productId);
        Task<bool> UpdateSync(int descriptionId, UpdateProductDescriptionDto newDescription);
        Task<bool> DeleteSync(int descriptionId);
    }
}
