using System.ComponentModel.DataAnnotations;

namespace API.Dtos.ProductDtos
{
    public class ProductUpdatedto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }
        [Required]
        [MaxLength(35)]
        public string BrandName { get; set; }
        [Range(0, int.MaxValue)]
        public decimal SalePrice { get; set; }
        [Range(0, int.MaxValue)]
        public decimal CostPrice { get; set; }

    }
}
