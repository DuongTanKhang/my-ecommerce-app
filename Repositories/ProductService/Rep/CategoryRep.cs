using AutoMapper;
using ECommerceBackend.Helper;
using ECommerceBackend.Models;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBackend.Repositories.ProductService.Rep
{
    public class CategoryRep : ICategoryRep
    {
        private readonly ECommerceMicroserviceContext _context;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TblCategory> _repository;

        public CategoryRep(ECommerceMicroserviceContext context, IMapper mapper, IGenericRepository<TblCategory> genericRepository)
        {
            _context = context;
            _mapper = mapper;
            _repository = genericRepository;
        }

        public Task<TblCategory> AddAsync(TblCategory category)
        {
            try
            {
                return _repository.Add(category);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding new category,{ex.Message}");
            }

        }

        public Task<IEnumerable<TblCategory?>> GetAllAsync()
        {
            try
            {
                var categories = _repository.GetAll();
                if (categories == null)
                    throw new KeyNotFoundException("Category not found");
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching categories, {ex.Message}");
            }

        }

        public Task<TblCategory?> GetByIdAsync(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching category with id:{id},{ex.Message}");

            }
        }

        public async Task<bool> UpdateAsync(int id, UpdateCategoryDto categoryDto)
        {
            try
            {
                var exsitingCategory = await _context.TblCategories.FindAsync(id);
                if (exsitingCategory == null)
                {
                    throw new Exception($"Category with id:{id} don't exsit");
                }
                _mapper.Map(categoryDto, exsitingCategory);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error updating catgegory with id:{id},{ex.Message}");
            }
        }

    }
}
