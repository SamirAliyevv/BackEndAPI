using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace API.Service.Dtos.BrandDtos
{
    public class BrandEditDto
    {
  
        public string Name { get; set; }
    }
    public class BrandEditDtoValidator : AbstractValidator<BrandEditDto>
    {
        public BrandEditDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(35).MinimumLength(2);
        }
    }
}
