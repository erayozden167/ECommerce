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
        public async Task<bool> PurchaseAddAsync(PurchaseDTO request)
        {
            Purchase purchase = new Purchase
            {
                UserId = request.UserId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                PurchaseDate = DateTime.Now
            };
            bool response = await _purchaseRepository.PurchaseAddAsync(purchase);
            if (!response)
            {
                return false;
            }

            return true;
        }

        public async Task<PurchaseDTO> GetPurchaseAsync(int id)
        {

            Purchase response = await _purchaseRepository.GetPurchaseAsync(id);

            if (response == null)
            {
                return new PurchaseDTO();
            }
            return new PurchaseDTO()
            {
                PurchaseId = response.PurchaseId,
                Quantity = response.Quantity,
                Product = response.Product
            };
        }
    }
}
