using BlazorServer.Data.Models.Domain;
using FluentValidation;

namespace BlazorServer.Validation;

public class CaseValidator : AbstractValidator<CaseRecord>
{
    public CaseValidator()
    {
        RuleFor(x => x.CaseReference).NotEmpty().WithMessage("Case reference is required");
    }
}