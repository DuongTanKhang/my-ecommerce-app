using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBackend.Controllers.ProductService
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductDescriptionController : ControllerBase
    {
        private readonly IProductDescriptionRep _rep;
        public ProductDescriptionController(IProductDescriptionRep productDescriptionRep)
        {
            _rep = productDescriptionRep;
        }

        [HttpGet("by-product/{productId}")]
        public async Task<ActionResult<IEnumerable<TblProductDescription>>> GetDescriptionByProduct(int productId)
        {
            try
            {
                var descriptions = await _rep.GetByProductIdSync(productId);
                return Ok(descriptions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error server:{ex.Message}");
            }
        }

        [HttpGet("{descriptionId}")]
        public async Task<ActionResult<TblProductDescription>> GetDescription(int descriptionId)
        {
            try
            {
                var description = await _rep.GetByIdAsync(descriptionId);
                return Ok(description);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error server:{ex.Message}");
            }
        }

        [HttpPost("by-product/{productId}")]
        public async Task<ActionResult<TblProductDescription>> AddDescription(int productId, [FromBody]ProductDescriptionDto newDescription)
        {
            try
            {
                var add = await _rep.AddSync(productId, newDescription);
                return CreatedAtAction(nameof(GetDescription), new { descriptionId = add.Id }, add);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error server:{ex.Message}");
            }
        }

        [HttpPut("{descriptionId}")]
        public async Task<IActionResult> UpdateDescription(int productId, [FromBody] ProductDescriptionDto description)
        {
            try
            {
                await _rep.UpdateSync(productId, description);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error server:{ex.Message}");
            }

        }

        [HttpDelete("{descriptionId}")]
        public async Task<IActionResult> DeleteDescription(int descriptionId)
        {
            try
            {
                await _rep.DeleteSync(descriptionId);
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error server:{ex.Message}");
            }
        }
    }
}
