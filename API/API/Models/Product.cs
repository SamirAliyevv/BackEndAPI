using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? BrandId { get; set; }

        public decimal SalePrice { get; set; }

        public decimal CostPrice { get; set; }
        public Brand? Brand { get; set; }
    }
}
