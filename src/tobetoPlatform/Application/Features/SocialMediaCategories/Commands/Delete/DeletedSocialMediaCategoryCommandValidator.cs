using FluentValidation;

namespace Application.Features.SocialMediaCategories.Commands.Delete;

public class DeleteSocialMediaCategoryCommandValidator : AbstractValidator<DeleteSocialMediaCategoryCommand>
{
    public DeleteSocialMediaCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}