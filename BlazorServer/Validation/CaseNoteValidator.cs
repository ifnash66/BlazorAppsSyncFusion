using FluentValidation;

namespace BlazorServer.Validation;

public class CaseNoteValidator : AbstractValidator<CaseNote>
{
    public CaseNoteValidator()
    {
        RuleFor(x => x.CaseNoteCategoryId).NotEmpty().GreaterThan(0).WithMessage("Case note category is required");
        RuleFor(x => x.NoteText).NotEmpty().WithMessage("Note text is required");
    }
}