using FluentValidation;

namespace Application.Features.UserApplications.Commands.Delete;

public class DeleteUserApplicationCommandValidator : AbstractValidator<DeleteUserApplicationCommand>
{
    public DeleteUserApplicationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}