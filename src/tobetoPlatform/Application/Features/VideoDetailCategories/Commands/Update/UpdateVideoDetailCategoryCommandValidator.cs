using FluentValidation;

namespace Application.Features.VideoDetailCategories.Commands.Update;

public class UpdateVideoDetailCategoryCommandValidator : AbstractValidator<UpdateVideoDetailCategoryCommand>
{
    public UpdateVideoDetailCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}