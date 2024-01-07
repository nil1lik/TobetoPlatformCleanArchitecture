using FluentValidation;

namespace Application.Features.EducationAboutCategories.Commands.Create;

public class CreateEducationAboutCategoryCommandValidator : AbstractValidator<CreateEducationAboutCategoryCommand>
{
    public CreateEducationAboutCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}