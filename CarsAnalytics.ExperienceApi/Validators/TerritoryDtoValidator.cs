using CarsAnalytics.ExperienceApi.Dto;
using FluentValidation;

namespace CarsAnalytics.ExperienceApi.Validators;

public class TerritoryDtoValidator : AbstractValidator<TerritoryDto>
{
    public TerritoryDtoValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .Length(2, 10)
            .Matches("^[A-Za-z]+$").WithMessage("Code must contain only letters"); 

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .Matches("^[A-Za-z]+$").WithMessage("Code must contain only letters"); 

        RuleFor(x => x.RegionCode)
            .NotEmpty()
            .Length(2, 10)
            .Matches("^[A-Za-z]+$").WithMessage("Code must contain only letters"); 
    }
}
