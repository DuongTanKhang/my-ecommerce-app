using ECommerceBackend.Models;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBackend.Repositories.ProductService.Rep
{
    public class ProductCategoryRep : IProductCategoryRep
    {
        private readonly ECommerceMicroserviceContext _context;
        public ProductCategoryRep(ECommerceMicroserviceContext context)
        {
            _context = context;
        }

        public async Task<bool> Addsync(int productId, int categoryId)
        {
            try
            {
                var productCategory = new TblProductCategory
                {
                    ProductId = productId,
                    CategoryId = categoryId
                };
                _context.TblProductCategories.Add(productCategory);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding product to category, {ex.Message}");
            }

        }

        public async Task<IEnumerable<TblCategory>> GetProductsByCategorySync(int categoryId)
        {
            try
            {
                var products =await  _context.TblProductCategories
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

        public async Task<bool> Removesync(int productId, int categoryId)
        {

            try
            {
                var productCategory = await _context.TblProductCategories.FirstOrDefaultAsync(pc => pc.ProductId == productId && pc.CategoryId == categoryId);
                if (productCategory == null)
                {
                    throw new Exception($"Error remove {productCategory}");
                }
                _context.TblProductCategories.Remove(productCategory);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error remove,{ex.Message}");

            }
        }
    }
}
