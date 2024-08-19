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
    public class PurchaseRepository
    {
        private readonly PurchaseContext _purchaseContext;
        public PurchaseRepository(PurchaseContext purchaseContext)
        {
            _purchaseContext = purchaseContext;
        }

        public async Task<bool> PurchaseAddAsync(Purchase purchase)
        {
            Product? product = await _purchaseContext.Products.FindAsync(purchase.ProductId);
            User? user = await _purchaseContext.Users.FindAsync(purchase.UserId);

            if (product == null || user == null)
            {
                return false;
            }
            if (product.StockQuantity < purchase.Quantity)
            {
                return false;
            }
            await _purchaseContext.Purchases.AddAsync(purchase);

            await _purchaseContext.Sales.AddAsync(new Sale
            {
                QuantitySold = purchase.Quantity,
                SaleDate = DateTime.UtcNow,
                ProductId = purchase.ProductId,
                SellerId = product.SellerId
            });

            product.StockQuantity -= purchase.Quantity;
            _purchaseContext.Products.Update(product);

            await _purchaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<Purchase> GetPurchaseAsync(int id)
        {
            Purchase? purchase = await _purchaseContext.Purchases.Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.UserId == id);
            if (purchase == null)
            {
                return new Purchase();
            }
            return purchase;
        }
    }
}
