using FluentValidation;

namespace Application.Features.SocialMediaAccounts.Commands.Update;

public class UpdateSocialMediaAccountCommandValidator : AbstractValidator<UpdateSocialMediaAccountCommand>
{
    public UpdateSocialMediaAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.SocialMediaCategoryId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.MediaUrl).NotEmpty();
    }
}