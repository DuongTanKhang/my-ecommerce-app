using ECommerceBackend.Models;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBackend.Controllers.ProductService
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductVariantController : ControllerBase
    {
        private readonly IProductVariantRep _rep;
        public ProductVariantController(IProductVariantRep productVariantRep)
        {
            _rep = productVariantRep;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProductVariant>> GetProductVariant(int id)
        {
            try
            {
                var productVariant = await _rep.GetByIdAsync(id);
                return Ok(productVariant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TblProductVariant>> CreateProductVariant(ProductVariantDto productVariantDto)
        {
            try
            {
                var add = await _rep.AddAsync(productVariantDto);
                return CreatedAtAction(nameof(GetProductVariant), new { id = add.Id }, add);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error {ex.Message}");
            }
        }

        [HttpGet("by-product/{productId}")]
        public async Task<ActionResult<IEnumerable<TblProductVariant>>> GetByProduct(int productID)
        {
            try
            {
                var productVariants = await _rep.GetVariantsByProductIdAsync(productID);
                return Ok(productVariants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVariant(int id, [FromBody] ProductVariantDto productVariantDto)
        {
            try
            {
                await _rep.UpdateAsync(id, productVariantDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVariant(int id)
        {
            try
            {
                await _rep.RemoveAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error {ex.Message}");
            }
        }
    }
}