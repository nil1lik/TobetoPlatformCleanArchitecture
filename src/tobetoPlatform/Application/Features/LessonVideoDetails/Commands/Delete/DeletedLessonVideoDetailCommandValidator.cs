using FluentValidation;

namespace Application.Features.LessonVideoDetails.Commands.Delete;

public class DeleteLessonVideoDetailCommandValidator : AbstractValidator<DeleteLessonVideoDetailCommand>
{
    public DeleteLessonVideoDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}