using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.Property(x=>x.Name).IsRequired(true).HasMaxLength(35);
            builder.Property(x => x.SalePrice).IsRequired(true).HasColumnType("money");
            builder.Property(x => x.CostPrice).IsRequired(true).HasColumnType("money");
            builder.HasOne(x=>x.Brand).WithMany(x=>x.Products).OnDelete(DeleteBehavior.NoAction);
        }
    }


}
