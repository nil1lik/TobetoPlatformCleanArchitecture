using FluentValidation;

namespace Application.Features.VideoDetailSubcategories.Commands.Update;

public class UpdateVideoDetailSubcategoryCommandValidator : AbstractValidator<UpdateVideoDetailSubcategoryCommand>
{
    public UpdateVideoDetailSubcategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.VideoDetailCategoryId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}