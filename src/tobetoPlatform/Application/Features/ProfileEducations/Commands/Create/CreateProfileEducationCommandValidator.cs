using FluentValidation;

namespace Application.Features.ProfileEducations.Commands.Create;

public class CreateProfileEducationCommandValidator : AbstractValidator<CreateProfileEducationCommand>
{
    public CreateProfileEducationCommandValidator()
    {
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.EducationPathId).NotEmpty();
    }
}