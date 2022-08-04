using BlazorServer.Data.Models.Domain;
using FluentValidation;

namespace BlazorServer.Validation;

public class GuestChildValidator : AbstractValidator<GuestChild>
{
    public GuestChildValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
        RuleFor(x => x.GenderId).NotEmpty().GreaterThan(0).WithMessage("Gender is required");
        RuleFor(x => x.DateOfBirth).NotEmpty().GreaterThan(DateTime.MinValue).WithMessage("Date of birth is required");
    }
}