using FluentValidation;

namespace Application.Features.UserApplications.Commands.Update;

public class UpdateUserApplicationCommandValidator : AbstractValidator<UpdateUserApplicationCommand>
{
    public UpdateUserApplicationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}