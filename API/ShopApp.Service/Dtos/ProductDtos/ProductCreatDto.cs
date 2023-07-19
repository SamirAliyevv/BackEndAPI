using FluentValidation;

namespace API.Service.Dtos.ProductDtos
{
    public class ProductCreatDto
    {

        public int BrandId { get; set; }
        public string Name { get; set; }
        public decimal  CostPrice { get; set; }
        public decimal  SalePrice { get; set; }

    }

    public class ProductCreatDtoValidator : AbstractValidator<ProductCreatDto>
    {

        public ProductCreatDtoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MinimumLength(2).MaximumLength(35);
            RuleFor(x => x.CostPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.SalePrice).GreaterThanOrEqualTo(x=>x.CostPrice);
            RuleFor(x => x.BrandId).GreaterThanOrEqualTo(1);
        }
    }
}
