using FluentValidation;

namespace Application.Features.LessonTypes.Commands.Update;

public class UpdateLessonTypeCommandValidator : AbstractValidator<UpdateLessonTypeCommand>
{
    public UpdateLessonTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}