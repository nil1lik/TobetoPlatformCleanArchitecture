using FluentValidation;

namespace Application.Features.ProfileSkills.Commands.Update;

public class UpdateProfileSkillCommandValidator : AbstractValidator<UpdateProfileSkillCommand>
{
    public UpdateProfileSkillCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.SkillId).NotEmpty();
    }
}