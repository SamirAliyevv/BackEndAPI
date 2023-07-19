using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppApi.Data.Configurations
{
    internal class Productconfiguration : IEntityTypeConfiguration<Product>
    {
        public void  Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(35);
            builder.Property(x => x.CostPrice).HasColumnType("money");
            builder.Property(x => x.SalePrice).HasColumnType("money");
            builder.HasOne(x=>x.Brand).WithMany(x => x.Products).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
