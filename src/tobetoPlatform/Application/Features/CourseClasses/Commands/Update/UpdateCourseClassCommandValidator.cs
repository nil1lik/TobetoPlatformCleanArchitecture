using FluentValidation;

namespace Application.Features.CourseClasses.Commands.Update;

public class UpdateCourseClassCommandValidator : AbstractValidator<UpdateCourseClassCommand>
{
    public UpdateCourseClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProfileAnnouncementId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}