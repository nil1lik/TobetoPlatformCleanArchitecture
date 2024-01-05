using FluentValidation;

namespace Application.Features.VideoDetailSubcategories.Commands.Delete;

public class DeleteVideoDetailSubcategoryCommandValidator : AbstractValidator<DeleteVideoDetailSubcategoryCommand>
{
    public DeleteVideoDetailSubcategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}