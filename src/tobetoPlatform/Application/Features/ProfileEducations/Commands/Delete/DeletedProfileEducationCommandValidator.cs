using FluentValidation;

namespace Application.Features.ProfileEducations.Commands.Delete;

public class DeleteProfileEducationCommandValidator : AbstractValidator<DeleteProfileEducationCommand>
{
    public DeleteProfileEducationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}