using AutoMapper;
using ECommerceBackend.Models;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBackend.Repositories.ProductService.Rep
{
    public class VariantAttributeRep : GenericRepository<TblVariantAttribute>, IVariantAttributeRep
    {
        private readonly ECommerceMicroserviceContext _context;
        private readonly IMapper _mapper;

        public VariantAttributeRep(ECommerceMicroserviceContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TblVariantAttribute> CreateAsync(VariantAttributeDto variantAttributeDto)
        {
            try
            {
                var newVariant = new TblVariantAttribute
                {
                    VariantId = variantAttributeDto.VariantId,
                    AttributeName = variantAttributeDto.AttributeName,
                    AttributeValue = variantAttributeDto.AttributeValue
                };
                return await Add(newVariant);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding new variant attribute,{ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting variant attribute with id:{id},{ex.Message}");
            }
        }

        public async Task<TblVariantAttribute?> GetByIdAsync(int id)
        {
            try
            {
                return await GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching attribute with id:{id},{ex.Message}");
            }
        }

        public async Task<IEnumerable<TblVariantAttribute?>> GetByVariantIdAsync(int variantId)
        {
            try
            {
                var variantAttributes = await _context.TblVariantAttributes
                                                .Where(x => x.VariantId == variantId)
                                                .ToListAsync();
                return variantAttributes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching variant attribute with variant id:{variantId},{ex.Message}");
            }
        }

        public async Task<bool> UpdateAsync(int id, VariantAttributeDto variantAttributeDto)
        {
            try
            {
                var exsiting = await GetById(id);
                _mapper.Map(exsiting, variantAttributeDto);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating variant attribute with id:{id},{ex.Message}");
            }

        }
    }
}
