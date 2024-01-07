using FluentValidation;

namespace Application.Features.EducationAboutCategories.Commands.Delete;

public class DeleteEducationAboutCategoryCommandValidator : AbstractValidator<DeleteEducationAboutCategoryCommand>
{
    public DeleteEducationAboutCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}