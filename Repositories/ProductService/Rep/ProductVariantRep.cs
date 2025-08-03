using AutoMapper;
using ECommerceBackend.Models;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBackend.Repositories.ProductService.Rep
{
    public class ProductVariantRep : GenericRepository<TblProductVariant>, IProductVariantRep
    {
        private readonly ECommerceMicroserviceContext _context;
        private readonly IMapper _mapper;
        public ProductVariantRep(ECommerceMicroserviceContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TblProductVariant> AddAsync(ProductVariantDto newProductVariant)
        {
            try
            {
                var add = new TblProductVariant
                {
                    ProductId = newProductVariant.ProductId,
                    StockQuanity = newProductVariant.StockQuanity,
                    Sku = newProductVariant.Sku,
                    Price = newProductVariant.Price,
                    VariantName = newProductVariant.VariantName,
                    ImageUrl = newProductVariant.ImageUrl,
                    Active = newProductVariant.Active,
                };
                return await Add(add);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding new product variant,{ex.Message}");
            }
        }

        public async Task<TblProductVariant?> GetByIdAsync(int id)
        {
            try
            {
                return await GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching product variant with id:{id},{ex.Message}");
            }
        }

        public async Task<IEnumerable<TblProductVariant?>> GetVariantsByProductIdAsync(int productId)
        {
            try
            {
                var productVariants = await _context.TblProductVariants
                                                .Where(x => x.ProductId == productId)
                                                .ToListAsync();
                if (productVariants.Count == 0)
                {
                    throw new Exception($"Product with id:{productId} doesn't has any variant");
                }
                return productVariants;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching all variants with product id:{productId},{ex.Message}");
            }

        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                return await Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting product variant with id:{id},{ex.Message}");
            }
        }

        public async Task<bool> UpdateAsync(int id, ProductVariantDto dto)
        {
            try
            {
                var exsiting = await GetById(id);
                if (exsiting == null)
                {
                    throw new Exception($"Product variant with id:{id} does not exist");
                }
                _mapper.Map(exsiting, dto);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating product variant with id:{id},{ex.Message}");
            }
        }
    }
}
