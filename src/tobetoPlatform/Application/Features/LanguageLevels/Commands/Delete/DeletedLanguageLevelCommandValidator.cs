using FluentValidation;

namespace Application.Features.LanguageLevels.Commands.Delete;

public class DeleteLanguageLevelCommandValidator : AbstractValidator<DeleteLanguageLevelCommand>
{
    public DeleteLanguageLevelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}