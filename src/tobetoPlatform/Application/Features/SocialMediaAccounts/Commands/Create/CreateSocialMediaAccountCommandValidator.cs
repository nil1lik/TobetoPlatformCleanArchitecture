using FluentValidation;

namespace Application.Features.SocialMediaAccounts.Commands.Create;

public class CreateSocialMediaAccountCommandValidator : AbstractValidator<CreateSocialMediaAccountCommand>
{
    public CreateSocialMediaAccountCommandValidator()
    {
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.SocialMediaCategoryId).NotEmpty();
        RuleFor(c => c.MediaUrl).NotEmpty();
    }
}