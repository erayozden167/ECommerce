using ECommerce.Business;
using ECommerce.Business.Interfaces;
using ECommerce.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
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
            UserDto? user = await _userService.GetAsync(id);
            return Ok(user);
        }
        //[HttpGet("seller")]
        //public async Task<IActionResult> GetSeller(int id)
        //{
        //    SellerDto? seller = await _userService.GetSellerAsync(id);
        //    if (seller == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(seller);
        //}
        //[HttpPost("Create/Shop")]
        //public async Task<IActionResult> AddSellerAsync(AddSellerDto seller)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    SellerDto? response = await _userService.AddSellerAsync(seller);
        //    if (response == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(response);
        //}
    }
}
