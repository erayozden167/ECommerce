using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Seller)
                   .WithMany(s => s.Products)
                   .HasForeignKey(p => p.SellerId);

            builder.HasMany(p => p.Purchases)
                   .WithOne(pu => pu.Product)
                   .HasForeignKey(p => p.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Sales)
                   .WithOne(s => s.Product)
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
