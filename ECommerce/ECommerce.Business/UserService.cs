using ECommerce.Business.Interfaces;
using ECommerce.Domain;
using ECommerce.DTOs;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto?> GetAsync(int id)
        {
            User? user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            UserDto userDTO = new UserDto()
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Role = user.Role
            };
            return userDTO;
        }
        
       
    }
}
