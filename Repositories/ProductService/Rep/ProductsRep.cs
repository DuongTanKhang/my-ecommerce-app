using AutoMapper;
using ECommerceBackend.Models;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ECommerceBackend.Repositories.ProductService.Rep
{
    public class ProductsRep : GenericRepository<TblProduct>, IProductsRep
    {
        private readonly ECommerceMicroserviceContext _context;
        private readonly IMapper _mapper;
        public ProductsRep(ECommerceMicroserviceContext context, IMapper mapper) :base(context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<TblProduct> AddAsync(ProductDto newProduct)
        {

            try
            {
                var product = new TblProduct
                {
                    Name = newProduct.Name,
                    Sku = newProduct.Sku,
                    Price = newProduct.Price,
                    StockQuanity = newProduct.StockQuanity,
                    Active = newProduct.Active,
                };
                await Add(product);
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding new product,{ex.Message}");
            }
        }
        public Task<IEnumerable<TblProduct?>> GetAllAsync()
        {
            try
            {
                return GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($" Error to fetching all products {ex.Message} ");
            }
        }

        public Task<TblProduct?> GetByIdAsync(int id)
        {
            try
            {
                return GetById(id);

            }
            catch (Exception ex)
            {
                throw new Exception($" Error fetching product with id: {id},{ex.Message} ");
            }
        }

        public async Task<bool> UpdateAsync(int id, ProductDto productDto)
        {
            try
            {
                var existingProduct = GetById(id);

                if (existingProduct == null)
                {
                    throw new Exception($"Product with id:{id} don't exsit");
                }
                _mapper.Map(existingProduct, productDto);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error updating product with id:{id},{ex.Message}");
            }
        }
    }
}
