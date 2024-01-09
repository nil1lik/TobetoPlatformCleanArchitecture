using FluentValidation;

namespace Application.Features.UserApplications.Commands.Create;

public class CreateUserApplicationCommandValidator : AbstractValidator<CreateUserApplicationCommand>
{
    public CreateUserApplicationCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}