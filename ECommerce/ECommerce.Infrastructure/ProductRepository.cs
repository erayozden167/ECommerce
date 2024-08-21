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
    public class ProductRepository
    {
        private readonly ProductContext _productContext;
        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public async Task<List<Product>> GetProductListAsync()
        {
            //no category
            return await _productContext.Products.ToListAsync();
        }
        public async Task<Product?> GetProductAsync(int id)
        {
            return await _productContext.Products.Include(p => p.Seller).FirstOrDefaultAsync(p => p.ProductId == id);
        }
    }
}
