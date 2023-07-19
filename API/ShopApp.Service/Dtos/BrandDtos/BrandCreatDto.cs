using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace API.Service.Dtos.BrandDtos
{
    public class BrandCreatDto
    {

        public string Name { get; set; }
    }
    public class BrandCreatDtoValidator : AbstractValidator<BrandCreatDto>
    {


        public BrandCreatDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(35);
        }
    }
}
