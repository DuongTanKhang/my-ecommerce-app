using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBackend.Controllers.ProductService
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageRep _rep;
        public ProductImageController(IProductImageRep productImageRep)
        {
            _rep = productImageRep;
        }

        [HttpGet("by-product/{productId}")]
        public async Task<ActionResult<IEnumerable<TblProductImage>>> GetImagesByProduct(int productId)
        {
            try
            {
                var images = await _rep.GetByProductIdAsync(productId);
                return Ok(images);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error:{ex.Message}");
            }
        }

        [HttpGet("{imageId}")]
        public async Task<ActionResult<TblProductImage>> GetImage(int imageId)
        {
            try
            {
                var image = await _rep.GetAsync(imageId);
                return Ok(image);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error {ex.Message}");
            }
        }

        [HttpPost("{productId}")]
        public async Task<ActionResult<TblProductImage>> AddImage(int productId, [FromBody] ProductImageDto newImage)
        {
            try
            {
                var add = await _rep.AddAsync(productId, newImage);
                return CreatedAtAction(nameof(GetImage), new { Id = add.Id }, add);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage(int id, ProductImageDto newImage)
        {
            try
            {
                await _rep.UpdateAsync(id, newImage);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error {ex.Message}");

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            try
            {
                await _rep.DeleteAsync(id);
                return NoContent();
            }catch(Exception ex)
            {
                return StatusCode(500, $"Error {ex.Message}");
            }
        }

    }
}
