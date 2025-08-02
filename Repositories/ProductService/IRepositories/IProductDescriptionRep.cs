using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;

namespace ECommerceBackend.Repositories.ProductService.IRepositories
{
    public interface IProductDescriptionRep
    {
        Task <TblProductDescription> AddSync(int productId, ProductDescriptionDto newDescription);
        Task<TblProductDescription?> GetByIdAsync(int descriptionId);
        Task<IEnumerable<TblProductDescription?>> GetByProductIdSync(int productId);
        Task<bool> UpdateSync(int descriptionId, ProductDescriptionDto newDescription);
        Task<bool> DeleteSync(int descriptionId);
    }
}
