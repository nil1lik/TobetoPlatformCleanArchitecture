using FluentValidation;

namespace Application.Features.VideoDetailCategories.Commands.Delete;

public class DeleteVideoDetailCategoryCommandValidator : AbstractValidator<DeleteVideoDetailCategoryCommand>
{
    public DeleteVideoDetailCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}