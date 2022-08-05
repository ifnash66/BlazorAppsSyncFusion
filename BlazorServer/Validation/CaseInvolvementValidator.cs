using BlazorServer.Data.Models.Domain;
using FluentValidation;

namespace BlazorServer.Validation;

public class CaseInvolvementValidator : AbstractValidator<CaseInvolvement>
{
    public CaseInvolvementValidator()
    {
        RuleFor(x => x.CaseRecordId).NotEmpty().GreaterThan(0).WithMessage("Case record is required");
        RuleFor(x => x.HostRecordId).NotEmpty().GreaterThan(0)
            .When(x => x.GuestRecordId == null && x.UserId == null).WithMessage("Host visited is required when guest and user are not selected");
        RuleFor(x => x.GuestRecordId).NotEmpty().GreaterThan(0)
            .When(x => x.HostRecordId == null && x.UserId == null).WithMessage("Guest visited is required when host and user are not selected");
        RuleFor(x => x.UserId).NotEmpty()
            .When(x => x.HostRecordId == null && x.GuestRecordId == null).WithMessage("User is required when host and guest are not selected");
    }
}