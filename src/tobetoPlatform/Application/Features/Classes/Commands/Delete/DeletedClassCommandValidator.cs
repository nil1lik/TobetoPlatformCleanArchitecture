using FluentValidation;

namespace Application.Features.Classes.Commands.Delete;

public class DeleteClassCommandValidator : AbstractValidator<DeleteClassCommand>
{
    public DeleteClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}