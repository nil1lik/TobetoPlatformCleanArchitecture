using FluentValidation;

namespace Application.Features.LessonTypes.Commands.Create;

public class CreateLessonTypeCommandValidator : AbstractValidator<CreateLessonTypeCommand>
{
    public CreateLessonTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}