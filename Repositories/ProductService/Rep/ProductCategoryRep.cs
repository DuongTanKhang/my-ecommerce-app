using AutoMapper;
using ECommerceBackend.Models;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBackend.Repositories.ProductService.Rep
{
    public class ProductCategoryRep : GenericRepository<TblProductCategory>, IProductCategoryRep
    {
        private readonly ECommerceMicroserviceContext _context;
        private readonly IMapper _mapper;

        public ProductCategoryRep(ECommerceMicroserviceContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
           
        }

        public async Task<TblProductCategory> AddAsync(ProductCategoryDto newProductCategory)
        {
            try
            {
                var add = new TblProductCategory
                {
                    ProductId = newProductCategory.ProductId,
                    CategoryId = newProductCategory.CategoryId
                };
                await Add(add);
                return add;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding product to category, {ex.Message}");
            }

        }

        public async Task<TblProductCategory> GetByIdAsync(int id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity == null)
                {
                    throw new Exception($"Don't exist entity with id:{id}");
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching entity with id:{id},{ex.Message}");
            }
        }

        public async Task<IEnumerable<TblProduct>> GetProductsByCategoryAsync(int categoryId)
        {
            try
            {
                var products = await _context.TblProductCategories
                    .Where(pc => pc.CategoryId == categoryId)
                    .Include(pc => pc.Product) // navigation property từ TblProductCategory → TblProduct
                    .Select(pc => pc.Product)
                    .ToListAsync();

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting products for category {categoryId}: {ex.Message}");
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
                throw new Exception($"Error remove,{ex.Message}");

            }
        }
        public async Task<bool> UpdateAsync(int id, ProductCategoryDto dto)
        {
            try
            {
                var exsiting = await GetById(id);
                if (exsiting == null)
                {
                    throw new Exception($"Entity with id:{id} don't exsit");
                }
                _mapper.Map(dto, exsiting);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed updating with id:{id},{ex.Message}");
            }
        }
    }
}
