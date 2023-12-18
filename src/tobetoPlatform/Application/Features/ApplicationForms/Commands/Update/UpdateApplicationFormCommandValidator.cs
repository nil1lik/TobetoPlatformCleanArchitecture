using FluentValidation;

namespace Application.Features.ApplicationForms.Commands.Update;

public class UpdateApplicationFormCommandValidator : AbstractValidator<UpdateApplicationFormCommand>
{
    public UpdateApplicationFormCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProfileDocumentFormId).NotEmpty();
        RuleFor(c => c.ProfileApplicationFormId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}