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
    public class PurchaseService
    {
        private readonly PurchaseRepository _purchaseRepository;
        public PurchaseService(PurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        public async Task<bool> PurchaseAsync(PurchaseDTO request)
        {
            Purchase purchase = new Purchase
            {
                UserId = request.UserId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                PurchaseDate = DateTime.Now
            };
            bool response = await _purchaseRepository.PurchaseAsync(purchase);
            if (!response)
            {
                return false;
            }

            return true;
        }
    }
}
