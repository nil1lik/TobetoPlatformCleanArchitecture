using FluentValidation;

namespace Application.Features.VideoDetailCategories.Commands.Create;

public class CreateVideoDetailCategoryCommandValidator : AbstractValidator<CreateVideoDetailCategoryCommand>
{
    public CreateVideoDetailCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}