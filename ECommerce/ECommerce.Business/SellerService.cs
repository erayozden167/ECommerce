using Azure.Core;
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
    public class SellerService : ISellerService
    {
        private readonly IUserRepository _userRepository;
        public SellerService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<SellerDto?> GetAsync(int sellerId)
        {
            Seller? seller = await _userRepository.GetSellerAsync(sellerId);
            if (seller == null)
            {
                return null;
            }

            SellerDto sellerDTO = new SellerDto()
            {
                SellerId = seller.SellerId,
                StoreName = seller.StoreName,
                CreatedDate = seller.CreatedDate,
                SalesCount = seller.Sales.Count
            };

            return sellerDTO;
        }

        public async Task<bool> AddAsync(AddSellerDto seller)
        {
            Seller entity = new Seller()
            {
                UserId = seller.UserId,
                StoreName = seller.StoreName,
                CreatedDate = DateTime.UtcNow,
                ApprovalStatus = "Beklemede"
            };
            bool response = await _userRepository.AddSellerAsync(entity);
            if (response == false)
            {
                return false;
            }
            //SellerDto sellerDTO = new SellerDto()
            //{
            //    SellerId = response.SellerId,
            //    UserId = response.UserId,
            //    StoreName = response.StoreName,
            //    ApprovalStatus = response.ApprovalStatus,
            //    CreatedDate = response.CreatedDate
            //};
            return true;
        }

        public async Task<bool> UpdateAsync(AddSellerDto updateSeller)
        {
            throw new NotImplementedException();
        }

        public async Task<SellerDto> ApprovalAsync(ApprovalSellerDto approval)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int sellerId)
        {
            throw new NotImplementedException();
        }

      
    }
}
