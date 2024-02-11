using FluentValidation;

namespace Application.Features.ProfileGraduations.Commands.Delete;

public class DeleteProfileGraduationCommandValidator : AbstractValidator<DeleteProfileGraduationCommand>
{
    public DeleteProfileGraduationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}