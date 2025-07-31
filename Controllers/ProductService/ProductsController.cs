using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBackend.Controllers.ProductService
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRep _rep;

        public ProductsController(IProductsRep rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCategory>>> GetProducts()
        {
            try
            {
                var products = await _rep.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error sever: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblProduct>> GetProduct(int id)
        {
            try
            {
                var product = await _rep.GetByIdAsync(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error sever: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TblProduct>> CreateProduct(TblProduct product)
        {
            try
            {
                var created = await _rep.AddAsync(product);
                return CreatedAtAction(nameof(GetProduct), new { id = created.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error sever: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody]UpdateProductDto product)
        {
            try
            {
                await _rep.UpdateAsync(id,product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error sever: {ex.Message}");
            }
        }
    }
}
