using FluentValidation;

namespace Application.Features.ProfileLessons.Commands.Create;

public class CreateProfileLessonCommandValidator : AbstractValidator<CreateProfileLessonCommand>
{
    public CreateProfileLessonCommandValidator()
    {
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.AsyncLessonId).NotEmpty();
        //RuleFor(c => c.IsWatched).NotEmpty();
    }
}