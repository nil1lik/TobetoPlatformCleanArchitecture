using FluentValidation;

namespace Application.Features.CatalogPaths.Commands.Delete;

public class DeleteCatalogPathCommandValidator : AbstractValidator<DeleteCatalogPathCommand>
{
    public DeleteCatalogPathCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}