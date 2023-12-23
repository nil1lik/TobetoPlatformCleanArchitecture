using FluentValidation;

namespace Application.Features.ProfileApplicationForms.Commands.Update;

public class UpdateProfileApplicationFormCommandValidator : AbstractValidator<UpdateProfileApplicationFormCommand>
{
    public UpdateProfileApplicationFormCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ApplicationFormId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ApprovalStatus).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
    }
}