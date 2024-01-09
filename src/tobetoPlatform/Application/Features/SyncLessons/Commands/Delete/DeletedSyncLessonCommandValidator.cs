using FluentValidation;

namespace Application.Features.SyncLessons.Commands.Delete;

public class DeleteSyncLessonCommandValidator : AbstractValidator<DeleteSyncLessonCommand>
{
    public DeleteSyncLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}