using ECommerce.Business;
using ECommerce.Business.Interfaces;
using ECommerce.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProductListAsync()
        {
            List<ProductDto> products = await _productService.GetListAsync();
            if (products.IsNullOrEmpty())
            {
                return NoContent();
            }
            return Ok(products);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            ProductInfoDto? product = await _productService.GetAsync(id);
            return Ok(product);
        }
    }
}
