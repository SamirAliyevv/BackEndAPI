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
    public class Brandconfiguration : IEntityTypeConfiguration<Brand>
    {
        public  void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(35);
        }
    }
}
