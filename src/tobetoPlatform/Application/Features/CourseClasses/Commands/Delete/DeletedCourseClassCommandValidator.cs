using FluentValidation;

namespace Application.Features.CourseClasses.Commands.Delete;

public class DeleteCourseClassCommandValidator : AbstractValidator<DeleteCourseClassCommand>
{
    public DeleteCourseClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}