using ECommerce.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Interfaces
{
    public interface ISellerService
    {
        Task<SellerDTO?> GetAsync(int sellerId);
        Task<SellerDTO?> AddAsync(AddSellerDTO seller);
        Task<SellerDTO?> UpdateAsync(AddSellerDTO updateSeller);
        Task<SellerDTO?> ApprovalAsync(ApprovalSellerDto approval);
        Task<bool> DeleteAsync(int sellerId);
    }
}
