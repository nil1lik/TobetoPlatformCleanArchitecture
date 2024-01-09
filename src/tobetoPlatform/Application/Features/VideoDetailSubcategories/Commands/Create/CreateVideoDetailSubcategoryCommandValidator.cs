using FluentValidation;

namespace Application.Features.VideoDetailSubcategories.Commands.Create;

public class CreateVideoDetailSubcategoryCommandValidator : AbstractValidator<CreateVideoDetailSubcategoryCommand>
{
    public CreateVideoDetailSubcategoryCommandValidator()
    {
        RuleFor(c => c.VideoDetailCategoryId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}