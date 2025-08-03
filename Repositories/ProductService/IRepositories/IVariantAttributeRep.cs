using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;

namespace ECommerceBackend.Repositories.ProductService.IRepositories
{
    public interface IVariantAttributeRep : IGenericRepository<TblVariantAttribute>
    {
        Task<TblVariantAttribute> CreateAsync(VariantAttributeDto variantAttributeDto);
        Task<bool> DeleteAsync(int id);
        Task<TblVariantAttribute?> GetByIdAsync(int id);
        Task<IEnumerable<TblVariantAttribute?>> GetByVariantIdAsync(int variantId);
        Task<bool> UpdateAsync(int id , VariantAttributeDto variantAttributeDto);

    }
}
