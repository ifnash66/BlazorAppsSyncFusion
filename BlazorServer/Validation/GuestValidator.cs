using BlazorServer.Data.Models.Domain;
using FluentValidation;

namespace BlazorServer.Validation;

public class GuestValidator : AbstractValidator<GuestRecord>
{
    public GuestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
        RuleFor(x => x.GenderId).NotEmpty().GreaterThan(0).WithMessage("Gender is required");
        RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("Email address is required");
        RuleFor(x => x.DateOfBirth).NotEmpty().GreaterThan(DateTime.MinValue).WithMessage("Date of birth is required");
        RuleFor(x => x.DateOfArrivalUk).NotEmpty().GreaterThan(DateTime.MinValue).WithMessage("Date of arrival in UK is required");
        RuleFor(x => x.DateOfArrivalAtAddress).NotEmpty().GreaterThan(DateTime.MinValue).WithMessage("Date of arrival at address is required");
    }
}