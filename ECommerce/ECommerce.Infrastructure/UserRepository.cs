using ECommerce.Data;
using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure
{
    public class UserRepository
    {
        private readonly UserSellerContext _userSellerContext;
        public UserRepository(UserSellerContext userSellerContext)
        {
            _userSellerContext = userSellerContext;
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userSellerContext.Users
                .FirstOrDefaultAsync(u => u.UserId == id);
        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userSellerContext.Users
                .Include(u => u.Seller)
                .FirstOrDefaultAsync(u=> u.Email == email);
        }
        public async Task<bool> AddUserAsync(User user)
        {
            try
            {
                await _userSellerContext.Users.AddAsync(user);
                await _userSellerContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public async Task<User?> GetSellerAsync(int id)
        {
            return await _userSellerContext.Users
                .Include(u => u.Seller).FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
