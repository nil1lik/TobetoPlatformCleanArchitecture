using FluentValidation;

namespace Application.Features.ProfileClasses.Commands.Delete;

public class DeleteProfileClassCommandValidator : AbstractValidator<DeleteProfileClassCommand>
{
    public DeleteProfileClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}