using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTOs
{
    public class UserInfoDto
    {
        public UserDto User { get; set; }
        public SellerDto Seller { get; set; }
    }
}
