using FluentValidation;

namespace Application.Features.ProfileApplications.Commands.Update;

public class UpdateProfileApplicationCommandValidator : AbstractValidator<UpdateProfileApplicationCommand>
{
    public UpdateProfileApplicationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProfileId).NotEmpty();
        RuleFor(c => c.ApplicationFormId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}