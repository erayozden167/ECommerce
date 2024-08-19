using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }

        //FK
        public int UserId { get; set; }
        public int ProductId { get; set; }

        // İlişkiler
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
