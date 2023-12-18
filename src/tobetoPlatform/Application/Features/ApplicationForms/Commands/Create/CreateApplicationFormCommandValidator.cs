using FluentValidation;

namespace Application.Features.ApplicationForms.Commands.Create;

public class CreateApplicationFormCommandValidator : AbstractValidator<CreateApplicationFormCommand>
{
    public CreateApplicationFormCommandValidator()
    {
        RuleFor(c => c.ProfileDocumentFormId).NotEmpty();
        RuleFor(c => c.ProfileApplicationFormId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}