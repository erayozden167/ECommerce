using ECommerce.Business;
using ECommerce.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            UserDTO? user = await _userService.GetUserAsync(id);
            return Ok(user);
        }
        [HttpGet("seller")]
        public async Task<IActionResult> GetSeller(int id)
        {
            UserSellerDTO? uSeller = await _userService.GetSellerAsync(id);
            if (uSeller == null)
            {
                return BadRequest();
            }
            return Ok(uSeller);
        }
        [HttpPost("Create/Shop")]
        public async Task<IActionResult> AddSellerAsync(AddSellerDTO seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SellerDTO? response = await _userService.AddSellerAsync(seller);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
