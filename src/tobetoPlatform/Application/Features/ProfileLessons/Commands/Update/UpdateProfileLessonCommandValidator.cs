using FluentValidation;

namespace Application.Features.ProfileLessons.Commands.Update;

public class UpdateProfileLessonCommandValidator : AbstractValidator<UpdateProfileLessonCommand>
{
    public UpdateProfileLessonCommandValidator()
    {
        //RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.AsyncLessonId).NotEmpty();
    }
}