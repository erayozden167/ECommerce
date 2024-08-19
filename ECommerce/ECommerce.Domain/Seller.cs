using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public string StoreName { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        //FK
        public int UserId { get; set; }

        // İlişkiler
        public virtual User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
