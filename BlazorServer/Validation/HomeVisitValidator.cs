using BlazorServer.Data.Models.Domain;
using FluentValidation;

namespace BlazorServer.Validation;

public class HomeVisitValidator : AbstractValidator<HomeVisitRecord>
{
    public HomeVisitValidator()
    {
        RuleFor(x => x.VisitDate).NotEmpty().GreaterThan(DateTime.MinValue).WithMessage("Visit date/time is required");
        RuleFor(x => x.VisitorName).NotEmpty().WithMessage("Visitor name is required");
        RuleFor(x => x.VisitStatusId).NotEmpty().GreaterThan(0).WithMessage("Visit status is required");
        RuleFor(x => x.HostsVisited).NotEmpty()
            .When(x => x.GuestsVisited == null).WithMessage("Host visited is required when guest visited is empty");
        RuleFor(x => x.GuestsVisited).NotEmpty()
            .When(x => x.HostsVisited == null).WithMessage("Guest visited is required when host visited is empty");
    }
}