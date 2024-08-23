using ECommerce.Data;
using ECommerce.Domain;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sm.Crm.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _userSellerContext;
        public UserRepository(ApplicationDbContext userSellerContext)
        {
            _userSellerContext = userSellerContext;
        }

        Task<List<User>> IUserRepository.GetListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userSellerContext.Users
                .FirstOrDefaultAsync(u => u.UserId == id);
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userSellerContext.Users
                .Include(u => u.Seller)
                .FirstOrDefaultAsync(u=> u.Email == email);
        }
        public async Task<bool> AddAsync(User user)
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

        Task<bool> IUserRepository.UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Seller---

        public async Task<Seller?> GetSellerAsync(int id)
        {
            User? user = await _userSellerContext.Users
                .Include(u => u.Seller).FirstOrDefaultAsync(u => u.UserId == id);
            return user?.Seller;
        }


        Task<List<Seller>> IUserRepository.GetListSeller()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddSellerAsync(Seller seller)
        {
            User? user = await _userSellerContext.Users.FirstOrDefaultAsync(s => s.UserId == seller.UserId);
            if (user == null || user.Role != "User")
            {
                return false;
            }
            seller.UserId = user.UserId;
            seller.User = user;
            user.Seller = seller;
            _userSellerContext.Users.Update(user);
            await _userSellerContext.SaveChangesAsync();

            return true;
        }

        Task<bool> IUserRepository.UpdateSellerAsync(Seller seller)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserRepository.DeleteSellerAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
