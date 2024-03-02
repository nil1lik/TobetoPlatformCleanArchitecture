using FluentValidation;

namespace Application.Features.CatalogPaths.Commands.Create;

public class CreateCatalogPathCommandValidator : AbstractValidator<CreateCatalogPathCommand>
{
    public CreateCatalogPathCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
        RuleFor(c => c.InstructorId).NotEmpty();
        RuleFor(c => c.AddedDate).NotEmpty();
    }
}