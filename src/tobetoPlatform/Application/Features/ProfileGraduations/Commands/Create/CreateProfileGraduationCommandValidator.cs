using FluentValidation;

namespace Application.Features.ProfileGraduations.Commands.Create;

public class CreateProfileGraduationCommandValidator : AbstractValidator<CreateProfileGraduationCommand>
{
    public CreateProfileGraduationCommandValidator()
    {
        RuleFor(c => c.GraduationId).NotEmpty();
        RuleFor(c => c.UserProfileId).NotEmpty();
    }
}