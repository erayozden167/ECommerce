using ECommerce.Business.Interfaces;
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
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDTO?> GetAsync(int id)
        {
            User? user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            UserDTO userDTO = new UserDTO()
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Role = user.Role
            };
            return userDTO;
        }
        public async Task<SellerDTO?> GetSellerAsync(int id)
        {
            Seller? seller = await _userRepository.GetSellerAsync(id);
            if (seller == null)
            {
                return null;
            }
            
            SellerDTO sellerDTO = new SellerDTO()
            {
                SellerId = seller.SellerId,
                StoreName = seller.StoreName,
                CreatedDate = seller.CreatedDate,
                SalesCount = seller.Sales.Count
            };
           
            return sellerDTO;
        }
        public async Task<SellerDTO?> AddSellerAsync(AddSellerDTO request)
        {
            Seller seller = new Seller()
            {
                UserId = request.UserId,
                StoreName = request.StoreName,
                CreatedDate = DateTime.UtcNow,
                ApprovalStatus = "Beklemede"
            };
            Seller? response = await _userRepository.AddSellerAsync(seller);
            if (response == null)
            {
                return null;
            }
            SellerDTO sellerDTO = new SellerDTO()
            {
                SellerId = response.SellerId,
                UserId = response.UserId,
                StoreName = response.StoreName,
                ApprovalStatus = response.ApprovalStatus,
                CreatedDate = response.CreatedDate
            };
            return sellerDTO;
        }
    }
}
