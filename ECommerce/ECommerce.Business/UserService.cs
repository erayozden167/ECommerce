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
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDTO?> GetUserAsync(int id)
        {
            User? user = await _userRepository.GetUserByIdAsync(id);
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
        public async Task<UserSellerDTO?> GetSellerAsync(int id)
        {
            User? user = await _userRepository.GetSellerAsync(id);
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
            SellerDTO sellerDTO = new SellerDTO()
            {
                SellerId = user.Seller.SellerId,
                StoreName = user.Seller.StoreName,
                CreatedDate = user.Seller.CreatedDate,
                SalesCount = user.Seller.Sales.Count
            };
            UserSellerDTO uSellerDTO = new UserSellerDTO()
            {
                User = userDTO,
                Seller = sellerDTO
            };
            return uSellerDTO;
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
