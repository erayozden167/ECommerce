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
            USellerDTO? uSeller = await _userService.GetSellerAsync(id);
            if (uSeller == null)
            {
                return BadRequest();
            }
            return Ok(uSeller);
        }
    }
}
