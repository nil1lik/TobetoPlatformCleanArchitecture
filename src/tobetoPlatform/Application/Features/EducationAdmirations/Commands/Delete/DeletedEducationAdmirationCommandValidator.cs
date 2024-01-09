using FluentValidation;

namespace Application.Features.EducationAdmirations.Commands.Delete;

public class DeleteEducationAdmirationCommandValidator : AbstractValidator<DeleteEducationAdmirationCommand>
{
    public DeleteEducationAdmirationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}