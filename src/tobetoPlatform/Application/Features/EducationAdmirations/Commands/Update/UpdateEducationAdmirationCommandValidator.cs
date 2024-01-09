using FluentValidation;

namespace Application.Features.EducationAdmirations.Commands.Update;

public class UpdateEducationAdmirationCommandValidator : AbstractValidator<UpdateEducationAdmirationCommand>
{
    public UpdateEducationAdmirationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.IsLiked).NotEmpty();
        RuleFor(c => c.IsFavourited).NotEmpty();
        RuleFor(c => c.CompletionRate).NotEmpty();
        RuleFor(c => c.EducationPoint).NotEmpty();
    }
}