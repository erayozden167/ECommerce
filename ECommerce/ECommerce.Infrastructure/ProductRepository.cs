using ECommerce.Data;
using ECommerce.Domain;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;
        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<List<Product>> GetListAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product?> GetAsync(int ProductId)
        {
            return await _productContext.Products.Include(p => p.Seller).FirstOrDefaultAsync(p => p.ProductId == ProductId);
        }

        public async Task<bool> AddAsync(Product product)
        {
            try
            {
                await _productContext.Products.AddAsync(product);
                await _productContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            Product? entity = await _productContext.Products.FindAsync(product.ProductId);
            if (entity == null)
            {
                return false;
            }

            entity = product;
            _productContext.Products.Update(entity);
            await _productContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int productId)
        {
            Product? entity = await _productContext.Products.FindAsync(productId);
            if (entity == null)
            {
                return false;
            }
            _productContext.Products.Remove(entity);
            await _productContext.SaveChangesAsync();
            return true;
        }
    }
}
