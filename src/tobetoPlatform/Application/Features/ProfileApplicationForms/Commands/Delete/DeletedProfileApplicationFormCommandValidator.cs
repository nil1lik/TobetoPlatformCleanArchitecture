using FluentValidation;

namespace Application.Features.ProfileApplicationForms.Commands.Delete;

public class DeleteProfileApplicationFormCommandValidator : AbstractValidator<DeleteProfileApplicationFormCommand>
{
    public DeleteProfileApplicationFormCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}