using FluentValidation;

namespace Application.Features.EducationAbouts.Commands.Delete;

public class DeleteEducationAboutCommandValidator : AbstractValidator<DeleteEducationAboutCommand>
{
    public DeleteEducationAboutCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}