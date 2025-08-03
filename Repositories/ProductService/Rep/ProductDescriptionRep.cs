using AutoMapper;
using ECommerceBackend.Models;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBackend.Repositories.ProductService.Rep
{
    public class ProductDescriptionRep : IProductDescriptionRep
    {
        private readonly ECommerceMicroserviceContext _context;
        private readonly IGenericRepository<TblProductDescription> _genericRepository;
        private readonly IGenericRepository<TblProduct> _productRepository;
        private readonly IMapper _mapper;

        public ProductDescriptionRep(ECommerceMicroserviceContext context, IGenericRepository<TblProductDescription> genericRepository, IGenericRepository<TblProduct> productRepository, IMapper mapper)
        {
            _context = context;
            _genericRepository = genericRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<TblProductDescription> AddSync(int productId, ProductDescriptionDto newDescription)
        {
            try
            {
                var exsitingProduct = await _productRepository.GetById(productId);
                if (exsitingProduct == null)
                {
                    throw new Exception($"product with {productId} does not exist");
                }

                var description = new TblProductDescription
                {
                    ProductId = productId,
                    Description = newDescription.Description
                };

                 return await _genericRepository.Add(description);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding description: {ex.Message}");

            }
        }

        public async Task<bool> DeleteSync(int descriptionId)
        {
            try
            {
                var description = await _genericRepository.GetById(descriptionId);
                if (description == null)
                {
                    throw new Exception("Error");
                }
                _context.TblProductDescriptions.Remove(description);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting description with id: {descriptionId},{ex.Message}");
            }
        }

        public async Task<TblProductDescription?> GetByIdAsync(int descriptionId)
        {
            try
            {
                var description = await _genericRepository.GetById(descriptionId);
                if (description == null)
                {
                    throw new Exception($"Description with id:{descriptionId} don't exsit");
                }
                return description;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblProductDescription?>> GetByProductIdSync(int productId)
        {
            try
            {
                var descriptions = await _context.TblProductDescriptions
                                            .Where(x => x.ProductId == productId)
                                            .ToListAsync();

                if (!descriptions.Any())
                {
                    throw new Exception($"Product with id:{productId} doesn't have any descriptions or doesn't exist.");

                }
                return descriptions;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching description with productId:{productId},{ex.Message}");
            }
        }

        public async Task<bool> UpdateSync(int descriptionId, ProductDescriptionDto newDescriptionDto)
        {
            try
            {
                var exsiting = await _genericRepository.GetById(descriptionId);
                if (exsiting == null)
                {
                    throw new Exception("dont exits");
                }
                _mapper.Map(newDescriptionDto, exsiting);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                throw new Exception($"Failed updating description,{ex.Message}");
            }
        }
    }
}
