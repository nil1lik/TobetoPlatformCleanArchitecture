using FluentValidation;

namespace Application.Features.CourseInstructors.Commands.Update;

public class UpdateCourseInstructorCommandValidator : AbstractValidator<UpdateCourseInstructorCommand>
{
    public UpdateCourseInstructorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.InstructorId).NotEmpty();
    }
}