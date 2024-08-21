using ECommerce.Domain;
using ECommerce.DTOs;
using ECommerce.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductDTO>> GetProductListAsync()
        {
            List<Product> products = await _productRepository.GetProductListAsync();
            if (products.IsNullOrEmpty())
            {
                return new List<ProductDTO>();
            }
            List<ProductDTO> listOfProduct = new List<ProductDTO>();
            foreach (var item in products)
            {
                ProductDTO productDTO = new ProductDTO()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                };
                listOfProduct.Add(productDTO);
            }
            return listOfProduct;
        }
        public async Task<ProductDetailDTO?> GetProductAsync(int id)
        {
            Product? product = await _productRepository.GetProductAsync(id);
            if (product == null)
            {
                return null;
            }
            ProductDetailDTO productDTO = new ProductDetailDTO()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Description = product.Description,
                SellerId = product.Seller.SellerId,
                StoreName = product.Seller.StoreName
            };
            return productDTO;
        }
    }
}
