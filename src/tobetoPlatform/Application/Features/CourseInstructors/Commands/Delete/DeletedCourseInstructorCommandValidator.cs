using FluentValidation;

namespace Application.Features.CourseInstructors.Commands.Delete;

public class DeleteCourseInstructorCommandValidator : AbstractValidator<DeleteCourseInstructorCommand>
{
    public DeleteCourseInstructorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}