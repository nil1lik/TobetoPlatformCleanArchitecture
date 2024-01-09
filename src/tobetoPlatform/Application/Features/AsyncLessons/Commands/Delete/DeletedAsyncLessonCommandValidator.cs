using FluentValidation;

namespace Application.Features.AsyncLessons.Commands.Delete;

public class DeleteAsyncLessonCommandValidator : AbstractValidator<DeleteAsyncLessonCommand>
{
    public DeleteAsyncLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}