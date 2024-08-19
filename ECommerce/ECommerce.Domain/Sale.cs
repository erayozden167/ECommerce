using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SellerId { get; set; }
        public Seller Seller { get; set; }

        public int QuantitySold { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
