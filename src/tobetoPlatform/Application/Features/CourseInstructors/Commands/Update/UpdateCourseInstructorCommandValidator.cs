using FluentValidation;

namespace Application.Features.CourseInstructors.Commands.Update;

public class UpdateCourseInstructorCommandValidator : AbstractValidator<UpdateCourseInstructorCommand>
{
    public UpdateCourseInstructorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}