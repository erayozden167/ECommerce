using ECommerce.Business;
using ECommerce.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductListAsync()
        {
            List<ProductDTO> products = await _productService.GetProductListAsync();
            if (products.IsNullOrEmpty())
            {
                return NoContent();
            }
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            ProductDetailDTO? product = await _productService.GetProductAsync(id);
            return Ok(product);
        }
    }
}
