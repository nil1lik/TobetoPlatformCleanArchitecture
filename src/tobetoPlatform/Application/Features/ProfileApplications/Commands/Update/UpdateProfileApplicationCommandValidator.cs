using FluentValidation;

namespace Application.Features.ProfileApplications.Commands.Update;

public class UpdateProfileApplicationCommandValidator : AbstractValidator<UpdateProfileApplicationCommand>
{
    public UpdateProfileApplicationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.UserApplicationId).NotEmpty();
    }
}