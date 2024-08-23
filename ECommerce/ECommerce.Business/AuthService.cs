using ECommerce.Business.Interfaces;
using ECommerce.Domain;
using ECommerce.DTOs;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business
{
    public class AuthService:IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly string _secretKey = GenerateSecretKey();
        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;

        }
        public async Task<bool> RegisterAsync(RegisterDto register)
        {
            string password = BCrypt.Net.BCrypt.HashPassword(register.Password);
            User user = new User()
            {
                Name = register.Name,
                Surname = register.Surname,
                Email = register.Email,
                PasswordHash = password,
                Role = "User"
            };
            bool result = await _userRepository.AddAsync(user);
            if (!result)
            {
                return false;
            }
            return true;
        }
        public async Task<AuthResultDto?> LoginAsync(LoginDto login)
        {
            var user = await _userRepository.GetByEmailAsync(login.Email);

            if (user == null)
            {
                return new AuthResultDto { IsSuccess = false };
            }

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                return new AuthResultDto { IsSuccess = false };
            }

            var token = GenerateJwtToken(user);

            return new AuthResultDto { IsSuccess = true, Token = token };
        }


        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey); // Make sure the key is sufficiently long (32 bytes or more)

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.UserId.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private static string GenerateSecretKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var key = new byte[32]; // 256 bits
                rng.GetBytes(key);
                return Convert.ToBase64String(key);
            }
        }
    }
}
