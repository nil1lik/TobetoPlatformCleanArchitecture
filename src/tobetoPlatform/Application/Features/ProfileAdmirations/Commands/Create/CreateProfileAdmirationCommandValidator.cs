using FluentValidation;

namespace Application.Features.ProfileAdmirations.Commands.Create;

public class CreateProfileAdmirationCommandValidator : AbstractValidator<CreateProfileAdmirationCommand>
{
    public CreateProfileAdmirationCommandValidator()
    {
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.EducationAdmirationId).NotEmpty();
        RuleFor(c => c.EducationPathId).NotEmpty();
    }
}