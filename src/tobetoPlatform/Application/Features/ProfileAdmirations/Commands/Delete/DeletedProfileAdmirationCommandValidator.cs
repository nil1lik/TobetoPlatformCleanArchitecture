using FluentValidation;

namespace Application.Features.ProfileAdmirations.Commands.Delete;

public class DeleteProfileAdmirationCommandValidator : AbstractValidator<DeleteProfileAdmirationCommand>
{
    public DeleteProfileAdmirationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}