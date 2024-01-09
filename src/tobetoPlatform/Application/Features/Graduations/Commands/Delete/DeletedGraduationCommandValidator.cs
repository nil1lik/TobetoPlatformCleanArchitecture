using FluentValidation;

namespace Application.Features.Graduations.Commands.Delete;

public class DeleteGraduationCommandValidator : AbstractValidator<DeleteGraduationCommand>
{
    public DeleteGraduationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}