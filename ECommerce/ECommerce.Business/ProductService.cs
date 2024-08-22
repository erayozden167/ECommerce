using ECommerce.Business.Interfaces;
using ECommerce.Domain;
using ECommerce.DTOs;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductDto>> GetListAsync()
        {
            List<Product> products = await _productRepository.GetListAsync();
            if (products.IsNullOrEmpty())
            {
                return new List<ProductDto>();
            }
            List<ProductDto> listOfProduct = new List<ProductDto>();
            foreach (var item in products)
            {
                ProductDto productDTO = new ProductDto()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                };
                listOfProduct.Add(productDTO);
            }
            return listOfProduct;
        }
        public async Task<ProductInfoDto?> GetAsync(int id)
        {
            Product? product = await _productRepository.GetAsync(id);
            if (product == null)
            {
                return null;
            }
            ProductInfoDto productDTO = new ProductInfoDto()
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
