using FluentValidation;

namespace Application.Features.EducationPaths.Commands.Delete;

public class DeleteEducationPathCommandValidator : AbstractValidator<DeleteEducationPathCommand>
{
    public DeleteEducationPathCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}