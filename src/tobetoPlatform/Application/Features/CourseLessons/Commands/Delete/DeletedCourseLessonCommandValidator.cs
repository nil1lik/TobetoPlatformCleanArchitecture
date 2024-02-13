using FluentValidation;

namespace Application.Features.CourseLessons.Commands.Delete;

public class DeleteCourseLessonCommandValidator : AbstractValidator<DeleteCourseLessonCommand>
{
    public DeleteCourseLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}