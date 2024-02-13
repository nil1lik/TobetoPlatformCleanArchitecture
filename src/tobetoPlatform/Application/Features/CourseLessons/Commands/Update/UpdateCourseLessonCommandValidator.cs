using FluentValidation;

namespace Application.Features.CourseLessons.Commands.Update;

public class UpdateCourseLessonCommandValidator : AbstractValidator<UpdateCourseLessonCommand>
{
    public UpdateCourseLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.AsyncLessonId).NotEmpty();
    }
}