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
        Task<SellerDto?> GetAsync(int sellerId);
        Task<bool> AddAsync(AddSellerDto seller);
        Task<bool> UpdateAsync(AddSellerDto updateSeller);
        Task<SellerDto?> ApprovalAsync(ApprovalSellerDto approval);
        Task<bool> DeleteAsync(int sellerId);
    }
}
