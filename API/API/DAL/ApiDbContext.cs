using API.Configurations;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace API.DAL
{
    public class ApiDbContext : DbContext
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {


        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration( new ProductConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }


    }
}
