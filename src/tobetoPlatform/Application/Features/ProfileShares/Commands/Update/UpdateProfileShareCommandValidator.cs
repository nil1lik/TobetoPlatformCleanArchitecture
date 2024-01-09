using FluentValidation;

namespace Application.Features.ProfileShares.Commands.Update;

public class UpdateProfileShareCommandValidator : AbstractValidator<UpdateProfileShareCommand>
{
    public UpdateProfileShareCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProfileUrl).NotEmpty();
        RuleFor(c => c.IsShare).NotEmpty();
    }
}