using FluentValidation;

namespace Application.Features.CourseLessons.Commands.Create;

public class CreateCourseLessonCommandValidator : AbstractValidator<CreateCourseLessonCommand>
{
    public CreateCourseLessonCommandValidator()
    {
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.AsyncLessonId).NotEmpty();
    }
}