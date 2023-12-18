using FluentValidation;

namespace Application.Features.CourseInstructors.Commands.Create;

public class CreateCourseInstructorCommandValidator : AbstractValidator<CreateCourseInstructorCommand>
{
    public CreateCourseInstructorCommandValidator()
    {
    }
}