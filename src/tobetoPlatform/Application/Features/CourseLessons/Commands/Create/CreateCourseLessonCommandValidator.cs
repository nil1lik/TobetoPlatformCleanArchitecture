using FluentValidation;

namespace Application.Features.CourseLessons.Commands.Create;

public class CreateCourseLessonCommandValidator : AbstractValidator<CreateCourseLessonCommand>
{
    public CreateCourseLessonCommandValidator()
    {
    }
}