using Azure.Core;
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
    public class SellerService : ISellerService
    {
        private readonly UserRepository _userRepository;
        public SellerService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<SellerDTO?> GetAsync(int sellerId)
        {
            Seller? seller = await _userRepository.GetSellerAsync(sellerId);
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

        public async Task<SellerDTO?> AddAsync(AddSellerDTO seller)
        {
            Seller entity = new Seller()
            {
                UserId = seller.UserId,
                StoreName = seller.StoreName,
                CreatedDate = DateTime.UtcNow,
                ApprovalStatus = "Beklemede"
            };
            Seller? response = await _userRepository.AddSellerAsync(entity);
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

        public async Task<SellerDTO> UpdateAsync(AddSellerDTO updateSeller)
        {
            throw new NotImplementedException();
        }

        public async Task<SellerDTO> ApprovalAsync(ApprovalSellerDto approval)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int sellerId)
        {
            throw new NotImplementedException();
        }

      
    }
}
