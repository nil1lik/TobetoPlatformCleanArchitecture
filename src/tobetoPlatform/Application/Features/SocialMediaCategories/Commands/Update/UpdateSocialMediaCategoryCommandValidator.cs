using FluentValidation;

namespace Application.Features.SocialMediaCategories.Commands.Update;

public class UpdateSocialMediaCategoryCommandValidator : AbstractValidator<UpdateSocialMediaCategoryCommand>
{
    public UpdateSocialMediaCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}