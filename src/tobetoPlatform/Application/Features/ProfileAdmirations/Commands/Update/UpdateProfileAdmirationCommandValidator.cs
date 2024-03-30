using FluentValidation;

namespace Application.Features.ProfileAdmirations.Commands.Update;

public class UpdateProfileAdmirationCommandValidator : AbstractValidator<UpdateProfileAdmirationCommand>
{
    public UpdateProfileAdmirationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.EducationAdmirationId).NotEmpty();
        RuleFor(c => c.EducationPathId).NotEmpty();
    }
}