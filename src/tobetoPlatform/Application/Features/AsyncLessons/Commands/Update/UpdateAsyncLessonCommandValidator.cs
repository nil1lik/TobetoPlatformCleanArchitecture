using FluentValidation;

namespace Application.Features.AsyncLessons.Commands.Update;

public class UpdateAsyncLessonCommandValidator : AbstractValidator<UpdateAsyncLessonCommand>
{
    public UpdateAsyncLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProfileEducationId).NotEmpty();
        RuleFor(c => c.CourseLessonId).NotEmpty();
        RuleFor(c => c.LessonVideoDetailId).NotEmpty();
        RuleFor(c => c.VideoCategoryId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.VideoUrl).NotEmpty();
    }
}