using FluentValidation;

namespace Application.Features.AsyncLessons.Commands.Create;

public class CreateAsyncLessonCommandValidator : AbstractValidator<CreateAsyncLessonCommand>
{
    public CreateAsyncLessonCommandValidator()
    {
        RuleFor(c => c.LessonVideoDetailId).NotEmpty();
        RuleFor(c => c.VideoCategoryId).NotEmpty();
        RuleFor(c => c.LessonTypeId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Time).NotEmpty();
        RuleFor(c => c.VideoUrl).NotEmpty();
        RuleFor(c => c.IsCompleted).NotEmpty();
    }
}

