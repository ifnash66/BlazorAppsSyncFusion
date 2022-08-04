using BlazorServer.Data.Models.Domain;
using FluentValidation;

namespace BlazorServer.Validation;

public class HostValidator : AbstractValidator<HostRecord>
{
    public HostValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
        RuleFor(x => x.BuildingNameNumber).NotEmpty().WithMessage("Building name/number is required");
        RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required");
        RuleFor(x => x.Town).NotEmpty().WithMessage("Town is required");
        RuleFor(x => x.Town).NotEmpty().WithMessage("Town is required");
        RuleFor(x => x.Postcode).NotEmpty().WithMessage("Postcode is required");
    }
}