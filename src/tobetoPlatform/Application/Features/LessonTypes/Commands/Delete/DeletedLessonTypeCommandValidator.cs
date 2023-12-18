using FluentValidation;

namespace Application.Features.LessonTypes.Commands.Delete;

public class DeleteLessonTypeCommandValidator : AbstractValidator<DeleteLessonTypeCommand>
{
    public DeleteLessonTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}