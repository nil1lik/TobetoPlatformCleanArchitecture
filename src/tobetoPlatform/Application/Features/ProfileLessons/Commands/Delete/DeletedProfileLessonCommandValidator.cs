using FluentValidation;

namespace Application.Features.ProfileLessons.Commands.Delete;

public class DeleteProfileLessonCommandValidator : AbstractValidator<DeleteProfileLessonCommand>
{
    public DeleteProfileLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}