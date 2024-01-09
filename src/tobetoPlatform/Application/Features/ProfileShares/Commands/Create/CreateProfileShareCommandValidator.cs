using FluentValidation;

namespace Application.Features.ProfileShares.Commands.Create;

public class CreateProfileShareCommandValidator : AbstractValidator<CreateProfileShareCommand>
{
    public CreateProfileShareCommandValidator()
    {
        RuleFor(c => c.ProfileUrl).NotEmpty();
        RuleFor(c => c.IsShare).NotEmpty();
    }
}