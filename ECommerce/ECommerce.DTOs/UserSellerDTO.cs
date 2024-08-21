using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTOs
{
    public class UserSellerDTO
    {
        public UserDTO User { get; set; }
        public SellerDTO Seller { get; set; }
    }
}
