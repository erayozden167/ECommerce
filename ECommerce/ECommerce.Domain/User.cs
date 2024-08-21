using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;
        //[Required]
        //[Range(typeof(DateTime),"1900-01-01","2024-01-01")]
        //public DateTime DateOfBirth { get; set; }
        [Required]
        public string Role { get; set; } = null!;

        //relationships

        public virtual Seller? Seller { get; set; }
        public virtual IEnumerable<Purchase> Purchases { get; set; }

    }
}
