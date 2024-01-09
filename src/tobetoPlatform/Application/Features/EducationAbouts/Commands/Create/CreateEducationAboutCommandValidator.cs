using FluentValidation;

namespace Application.Features.EducationAbouts.Commands.Create;

public class CreateEducationAboutCommandValidator : AbstractValidator<CreateEducationAboutCommand>
{
    public CreateEducationAboutCommandValidator()
    {
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.EducationAboutCategoryId).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
    }
}