using FluentValidation;

namespace Application.Features.ProfileApplications.Commands.Delete;

public class DeleteProfileApplicationCommandValidator : AbstractValidator<DeleteProfileApplicationCommand>
{
    public DeleteProfileApplicationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}