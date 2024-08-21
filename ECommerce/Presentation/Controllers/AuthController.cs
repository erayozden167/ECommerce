using ECommerce.Business;
using ECommerce.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserRegisterDTO register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            bool result = await _authService.RegisterAsync(register);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            AuthResultDTO result = await _authService.LoginAsync(login);
            if (!result.IsSuccess)
            {
                return Unauthorized("Kullanıcı adı veya şifre hatalı");
            }

            return Ok( new { Token = result.Token });
        }
    }
}
