using ECommerce.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> GetAsync(int id);
     
    }
}
