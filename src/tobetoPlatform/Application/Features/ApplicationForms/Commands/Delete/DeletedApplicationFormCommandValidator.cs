using FluentValidation;

namespace Application.Features.ApplicationForms.Commands.Delete;

public class DeleteApplicationFormCommandValidator : AbstractValidator<DeleteApplicationFormCommand>
{
    public DeleteApplicationFormCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}