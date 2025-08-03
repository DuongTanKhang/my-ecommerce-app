using AutoMapper;
using ECommerceBackend.Models;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBackend.Repositories.ProductService.Rep
{
    public class ProductImageRep : GenericRepository<TblProductImage>, IProductImageRep
    {
        private readonly ECommerceMicroserviceContext _context;
        private readonly IGenericRepository<TblProduct> _productGenericReposity;
        private readonly IMapper _mapper;

        public ProductImageRep(IMapper mapper, IGenericRepository<TblProduct> productGenericReposity, ECommerceMicroserviceContext context) :base(context)
        {
            _context = context;
            _mapper = mapper;
            _productGenericReposity = productGenericReposity;
        }
        public async Task<TblProductImage> AddAsync(int productId, ProductImageDto productImageDto)
        {
            var product = await _productGenericReposity.GetById(productId);
            if (product == null)
            {
                throw new Exception($"Product with id:{productId} doesn't exsit");
            }
            var imageProduct = new TblProductImage
            {
                ProductId = productId,
                ImageUrl = productImageDto.ImageUrl,
            };
            return await Add(imageProduct);
        }

        public async Task<bool> DeleteAsync(int imageId)
        {
            try
            {
                return await Delete(imageId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting entity with id:{imageId},{ex.Message}");
            }
        }

        public async Task<TblProductImage?> GetAsync(int imageId)
        {
            try
            {
                return await GetById(imageId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Entity with id:{imageId} doesn't exsit,{ex.Message}");
            }
        }

        public async Task<IEnumerable<TblProductImage?>> GetByProductIdAsync(int productId)
        {
            var images = await _context.TblProductImages
                                  .Where(x => x.Id == productId)
                                  .ToListAsync();
            if (!images.Any())
            {
                throw new Exception($"Product with id:{productId} has no image");
            }
            return images;
        }

        public async Task<bool> UpdateAsync(int id, ProductImageDto image)
        {
            try
            {
                var entity = GetById(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with id:{id} doesn't exsit");
                }
                _mapper.Map(entity, image);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating entity with id:{id},{ex.Message}");
            }

        }
    }
}
