using FluentValidation;

namespace Application.Features.ProfileLanguages.Commands.Delete;

public class DeleteProfileLanguageCommandValidator : AbstractValidator<DeleteProfileLanguageCommand>
{
    public DeleteProfileLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}