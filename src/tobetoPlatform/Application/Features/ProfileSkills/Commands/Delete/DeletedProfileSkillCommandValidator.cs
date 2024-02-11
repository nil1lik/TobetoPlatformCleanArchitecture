using FluentValidation;

namespace Application.Features.ProfileSkills.Commands.Delete;

public class DeleteProfileSkillCommandValidator : AbstractValidator<DeleteProfileSkillCommand>
{
    public DeleteProfileSkillCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}