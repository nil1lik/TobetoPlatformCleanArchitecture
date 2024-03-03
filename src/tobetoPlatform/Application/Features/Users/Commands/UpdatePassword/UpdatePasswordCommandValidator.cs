using Application.Features.Users.Commands.UpdatePassword;
using FluentValidation;

public class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
{
    public UpdatePasswordCommandValidator()
    {
        RuleFor(c => c.NewPassword).NotEmpty().MinimumLength(8);
    }
}
