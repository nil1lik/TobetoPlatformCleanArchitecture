using FluentValidation;

namespace Application.Features.ProfileShares.Commands.Delete;

public class DeleteProfileShareCommandValidator : AbstractValidator<DeleteProfileShareCommand>
{
    public DeleteProfileShareCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}