using ECommerce.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetListAsync();
        Task<ProductInfoDto?> GetAsync(int id);
    }
}
