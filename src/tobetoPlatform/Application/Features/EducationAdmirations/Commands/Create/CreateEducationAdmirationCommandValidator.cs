using FluentValidation;

namespace Application.Features.EducationAdmirations.Commands.Create;

public class CreateEducationAdmirationCommandValidator : AbstractValidator<CreateEducationAdmirationCommand>
{
    public CreateEducationAdmirationCommandValidator()
    {
        RuleFor(c => c.IsLiked).NotEmpty();
        RuleFor(c => c.IsFavourited).NotEmpty();
        RuleFor(c => c.CompletionRate).NotEmpty();
        RuleFor(c => c.EducationPoint).NotEmpty();
    }
}