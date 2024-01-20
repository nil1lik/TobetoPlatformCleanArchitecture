using FluentValidation;

namespace Application.Features.SyncLessons.Commands.Create;

public class CreateSyncLessonCommandValidator : AbstractValidator<CreateSyncLessonCommand>
{
    public CreateSyncLessonCommandValidator()
    {
        RuleFor(c => c.LessonVideoDetailId).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.SyncVideoUrl).NotEmpty();
        RuleFor(c => c.SessionName).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        //RuleFor(c => c.Time).NotEmpty();
        RuleFor(c => c.IsJoin).NotEmpty();
    }
}