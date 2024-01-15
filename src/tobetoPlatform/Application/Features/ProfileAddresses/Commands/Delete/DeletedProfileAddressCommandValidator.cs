using FluentValidation;

namespace Application.Features.ProfileAddresses.Commands.Delete;

public class DeleteProfileAddressCommandValidator : AbstractValidator<DeleteProfileAddressCommand>
{
    public DeleteProfileAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}