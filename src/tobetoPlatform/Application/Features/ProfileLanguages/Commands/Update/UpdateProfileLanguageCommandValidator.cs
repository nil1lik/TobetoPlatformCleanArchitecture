using FluentValidation;

namespace Application.Features.ProfileLanguages.Commands.Update;

public class UpdateProfileLanguageCommandValidator : AbstractValidator<UpdateProfileLanguageCommand>
{
    public UpdateProfileLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.LanguageId).NotEmpty();
    }
}