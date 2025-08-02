using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace ECommerceBackend.Controllers.ProductService
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRep _rep;
        public ProductCategoryController(IProductCategoryRep productCategoryRep)
        {
            _rep = productCategoryRep;
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetByCategory(int categoryId)
        {
            try
            {
                var productsByCategory = await _rep.GetProductsByCategoryAsync(categoryId);
                if (productsByCategory == null)
                {
                    throw new Exception($"There are no product in category with id{categoryId}");
                }
                return Ok(productsByCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error server:{ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblProductCategory>> GetById(int id)
        {
            try
            {
                var entity = await _rep.GetByIdAsync(id);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error server:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TblProductCategory>> AddNewRelationship([FromBody]ProductCategoryDto tblProductCategory)
        {
            try
            {
                var add = await _rep.AddAsync(tblProductCategory);
                return CreatedAtAction(nameof(GetById), new { id = add.Id }, add);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error server:{ex.Message}");
            }

        }
    }
}
