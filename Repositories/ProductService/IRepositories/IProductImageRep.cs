using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;

namespace ECommerceBackend.Repositories.ProductService.IRepositories
{
    public interface IProductImageRep : IGenericRepository<TblProductImage>
    {
        Task<IEnumerable<TblProductImage?>> GetByProductIdAsync(int productId);

        Task<TblProductImage?> GetAsync(int imageId);

        Task<bool> DeleteAsync(int imageId);

        Task<bool> UpdateAsync(int id,ProductImageDto image);

        Task<TblProductImage> AddAsync(int productId,ProductImageDto productImageDto);
    }
}
