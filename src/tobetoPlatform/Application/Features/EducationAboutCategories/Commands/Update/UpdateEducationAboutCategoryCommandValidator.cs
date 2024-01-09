using FluentValidation;

namespace Application.Features.EducationAboutCategories.Commands.Update;

public class UpdateEducationAboutCategoryCommandValidator : AbstractValidator<UpdateEducationAboutCategoryCommand>
{
    public UpdateEducationAboutCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}