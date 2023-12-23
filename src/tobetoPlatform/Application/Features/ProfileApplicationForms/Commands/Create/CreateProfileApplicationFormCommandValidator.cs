using FluentValidation;

namespace Application.Features.ProfileApplicationForms.Commands.Create;

public class CreateProfileApplicationFormCommandValidator : AbstractValidator<CreateProfileApplicationFormCommand>
{
    public CreateProfileApplicationFormCommandValidator()
    {
        RuleFor(c => c.ApplicationFormId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ApprovalStatus).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
    }
}