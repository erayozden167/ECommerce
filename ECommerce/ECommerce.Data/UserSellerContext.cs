using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain;

namespace ECommerce.Data
{
    public class UserSellerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public UserSellerContext(DbContextOptions<UserSellerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(s => s.Seller)
                .WithOne(u => u.User)
                .HasForeignKey<Seller>(s => s.UserId);
        }
    }
}
