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
        private readonly IGenericRepository<TblCategory> _genericRepository;

        public CategoryRep(ECommerceMicroserviceContext context, IMapper mapper, IGenericRepository<TblCategory> genericRepository)
        {
            _context = context;
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public async Task<TblCategory> AddAsync(CategoryDto newCategory)
        {
            try
            {
                var category = new TblCategory
                {
                    Name = newCategory.Name,
                    Slug = newCategory.Slug,
                    ParentId = newCategory.ParentId,
                    ImageUrl = newCategory.ImageUrl,
                    Description = newCategory.Description,
                    Active = newCategory.Active,
                };
                await _genericRepository.Add(category);
                return category;
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
                var categories = _genericRepository.GetAll();
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
                return _genericRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching category with id:{id},{ex.Message}");

            }
        }

        public async Task<bool> UpdateAsync(int id, CategoryDto categoryDto)
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

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _genericRepository.Delete(id);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting category with id:{id},{ex.Message}");
            }

        }

    }
}
