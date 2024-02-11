using FluentValidation;

namespace Application.Features.ProfileSkills.Commands.Create;

public class CreateProfileSkillCommandValidator : AbstractValidator<CreateProfileSkillCommand>
{
    public CreateProfileSkillCommandValidator()
    {
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.SkillId).NotEmpty();
    }
}