using FluentValidation;

namespace Application.Features.CatalogPaths.Commands.Update;

public class UpdateCatalogPathCommandValidator : AbstractValidator<UpdateCatalogPathCommand>
{
    public UpdateCatalogPathCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
        RuleFor(c => c.InstructorId).NotEmpty();
        RuleFor(c => c.Time).NotEmpty();
    }
}