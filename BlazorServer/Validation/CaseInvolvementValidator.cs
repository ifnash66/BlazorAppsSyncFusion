using BlazorServer.Data.Models.Domain;
using FluentValidation;

namespace BlazorServer.Validation;

public class CaseInvolvementValidator : AbstractValidator<CaseInvolvement>
{
    public CaseInvolvementValidator()
    {
        RuleFor(x => x.CaseRecordId).NotEmpty().GreaterThan(0).WithMessage("Case record is required");
        RuleFor(x => x.HostRecordId).NotEmpty().GreaterThan(0)
            .When(x => x.GuestRecordId == null).WithMessage("Host visited is required when guest visited is empty");
        RuleFor(x => x.GuestRecordId).NotEmpty().GreaterThan(0)
            .When(x => x.HostRecordId == null).WithMessage("Guest visited is required when host visited is empty");
    }
}