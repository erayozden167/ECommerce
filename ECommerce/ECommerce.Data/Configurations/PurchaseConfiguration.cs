using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasOne(p => p.User)
                   .WithMany(u => u.Purchases)
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(p => p.Product)
                   .WithMany(pr => pr.Purchases)
                   .HasForeignKey(p => p.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
