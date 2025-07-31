using AutoMapper;
using ECommerceBackend.Models;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ECommerceBackend.Repositories.ProductService.Rep
{
    public class ProductsRep : IProductsRep
    {
        private readonly ECommerceMicroserviceContext _context;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TblProduct> _repository;
        public ProductsRep(IMapper mapper, IGenericRepository<TblProduct> genericRepository, ECommerceMicroserviceContext context)
        {
            _mapper = mapper;
            _repository = genericRepository;
            _context = context;
        }
        public Task<TblProduct> AddAsync(TblProduct product)
        {

            try
            {
                return _repository.Add(product);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding new product,{ex.Message}");
            }
        }
        public Task<IEnumerable<TblProduct>> GetAllAsync()
        {
            try
            {
                return _repository.GetAll();
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
                return _repository.GetById(id);

            }
            catch (Exception ex)
            {
                throw new Exception($" Error fetching product with id: {id},{ex.Message} ");
            }
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto productDto)
        {
            try
            {
                var existingProduct = _repository.GetById(id);

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
