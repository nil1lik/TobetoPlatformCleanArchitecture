using FluentValidation;

namespace Application.Features.EducationAbouts.Commands.Update;

public class UpdateEducationAboutCommandValidator : AbstractValidator<UpdateEducationAboutCommand>
{
    public UpdateEducationAboutCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.EducationAboutCategoryId).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.EstimatedDuration).NotEmpty();
    }
}