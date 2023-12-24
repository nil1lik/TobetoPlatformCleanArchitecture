using FluentValidation;

namespace Application.Features.ProfileApplications.Commands.Create;

public class CreateProfileApplicationCommandValidator : AbstractValidator<CreateProfileApplicationCommand>
{
    public CreateProfileApplicationCommandValidator()
    {
        RuleFor(c => c.ProfileId).NotEmpty();
        RuleFor(c => c.ApplicationFormId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}