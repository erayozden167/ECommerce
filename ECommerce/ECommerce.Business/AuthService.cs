using ECommerce.Business.Interfaces;
using ECommerce.Domain;
using ECommerce.DTOs;
using ECommerce.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.Business
{
    public class AuthService : IAuthService
    {
        private readonly UserRepository _userRepository;
        private readonly string _secretKey; 
        public AuthService(UserRepository userRepository, string secretKey)
        {
            _userRepository = userRepository;
            _secretKey = secretKey;
        }
        public async Task<bool> RegisterAsync(RegisterDto register)
        {
            string password = BCrypt.Net.BCrypt.HashPassword(register.Password);
            User user = new User()
            {
                Name = register.Name,
                Surname = register.Surname,
                Email = register.Email,
                PasswordHash = password
            };
            bool result = await _userRepository.AddAsync(user);
            if (!result)
            {
                return false;
            }
            return true;
        }
        public async Task<AuthResultDTO> LoginAsync(LoginDTO login)
        {
            User? user = await _userRepository.GetByEmailAsync(login.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password,user.PasswordHash))
            {
                return new AuthResultDTO() { IsSuccess = false};
            }

            string token = GenerateJwtToken(user);

            return new AuthResultDTO() { IsSuccess = true,Token =token};
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2), // Token geçerlilik süresi
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
