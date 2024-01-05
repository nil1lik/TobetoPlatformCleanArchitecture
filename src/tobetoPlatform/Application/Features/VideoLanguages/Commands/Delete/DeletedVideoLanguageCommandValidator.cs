using FluentValidation;

namespace Application.Features.VideoLanguages.Commands.Delete;

public class DeleteVideoLanguageCommandValidator : AbstractValidator<DeleteVideoLanguageCommand>
{
    public DeleteVideoLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}