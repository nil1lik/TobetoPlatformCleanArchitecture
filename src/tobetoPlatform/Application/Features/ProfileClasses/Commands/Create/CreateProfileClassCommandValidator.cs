using FluentValidation;

namespace Application.Features.ProfileClasses.Commands.Create;

public class CreateProfileClassCommandValidator : AbstractValidator<CreateProfileClassCommand>
{
    public CreateProfileClassCommandValidator()
    {
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.CourseClassId).NotEmpty();
        RuleFor(c => c.EducationPathId).NotEmpty();
    }
}