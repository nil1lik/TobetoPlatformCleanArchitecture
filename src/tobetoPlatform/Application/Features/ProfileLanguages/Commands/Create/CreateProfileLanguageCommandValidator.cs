using FluentValidation;

namespace Application.Features.ProfileLanguages.Commands.Create;

public class CreateProfileLanguageCommandValidator : AbstractValidator<CreateProfileLanguageCommand>
{
    public CreateProfileLanguageCommandValidator()
    {
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.LanguageId).NotEmpty();
    }
}