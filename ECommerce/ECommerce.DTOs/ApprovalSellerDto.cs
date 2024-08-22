using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTOs
{
    internal class ApprovalSellerDto
    {
        public int SellerId { get; set; }
        public string ApprovalStatus { get; set; } = null!;
    }
}
