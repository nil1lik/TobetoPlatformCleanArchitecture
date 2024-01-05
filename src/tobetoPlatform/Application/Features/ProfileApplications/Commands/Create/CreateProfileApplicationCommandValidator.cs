using FluentValidation;

namespace Application.Features.ProfileApplications.Commands.Create;

public class CreateProfileApplicationCommandValidator : AbstractValidator<CreateProfileApplicationCommand>
{
    public CreateProfileApplicationCommandValidator()
    {
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.UserApplicationId).NotEmpty();
    }
}