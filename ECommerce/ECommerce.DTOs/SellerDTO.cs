using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTOs
{
    public class SellerDTO
    {
        public int SellerId { get; set; }
        public string StoreName { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SalesCount { get; set; }
    }
}
