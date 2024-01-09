using FluentValidation;

namespace Application.Features.SocialMediaCategories.Commands.Create;

public class CreateSocialMediaCategoryCommandValidator : AbstractValidator<CreateSocialMediaCategoryCommand>
{
    public CreateSocialMediaCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}