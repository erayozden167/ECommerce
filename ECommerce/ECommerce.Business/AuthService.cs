using ECommerce.Domain;
using ECommerce.DTOs;
using ECommerce.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.Business
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;
        
        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> RegisterAsync(UserRegisterDTO register)
        {
            string password = BCrypt.Net.BCrypt.HashPassword(register.Password);
            User user = new User()
            {
                Name = register.Name,
                Surname = register.Surname,
                Email = register.Email,
                PasswordHash = password
            };
            bool result = await _userRepository.AddUserAsync(user);
            if (!result)
            {
                return false;
            }
            return true;
        }
        public async Task<AuthResultDTO> LoginAsync(LoginDTO login)
        {
            User? user = await _userRepository.GetUserByEmailAsync(login.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password,user.PasswordHash))
            {
                return new AuthResultDTO() { IsSuccess = false};
            }

            string token = "Create Token Here <==";

            return new AuthResultDTO() { IsSuccess = true,Token =token};
        }
        
    }
}
