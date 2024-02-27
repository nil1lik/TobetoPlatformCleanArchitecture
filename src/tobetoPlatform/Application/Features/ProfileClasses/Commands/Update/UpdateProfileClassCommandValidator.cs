using FluentValidation;

namespace Application.Features.ProfileClasses.Commands.Update;

public class UpdateProfileClassCommandValidator : AbstractValidator<UpdateProfileClassCommand>
{
    public UpdateProfileClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.CourseClassId).NotEmpty();
        RuleFor(c => c.EducationPathId).NotEmpty();
    }
}