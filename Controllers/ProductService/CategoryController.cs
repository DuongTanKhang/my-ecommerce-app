using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using ECommerceBackend.Repositories.ProductService.Rep;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBackend.Controllers.ProductService
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRep _rep;
        public CategoryController(ICategoryRep rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCategory>>> GetCategories()
        {
            try
            {
                var cateogries = await _rep.GetAllAsync();
                return Ok(cateogries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error server:{ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCategory>> GetCategory(int id)
        {
            try
            {
                var category = await _rep.GetByIdAsync(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error server:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TblCategory>> CreateCategory(TblCategory category)
        {
            try
            {
                var created = await _rep.AddAsync(category);
                return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error server:{ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto category)
        {
            try
            {
                await _rep.UpdateAsync(id, category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error server:{ex.Message}");
            }
        }

    }
}
