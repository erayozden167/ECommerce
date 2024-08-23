using ECommerce.Data;
using ECommerce.Domain;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sm.Crm.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetListAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetAsync(int productId)
        {
            return await _context.Products
                                 .Include(p => p.Seller)
                                 .FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<bool> AddAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var entity = await _context.Products.FindAsync(product.ProductId);
            if (entity == null)
            {
                return false;
            }

            _context.Entry(entity).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int productId)
        {
            var entity = await _context.Products.FindAsync(productId);
            if (entity == null)
            {
                return false;
            }

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
