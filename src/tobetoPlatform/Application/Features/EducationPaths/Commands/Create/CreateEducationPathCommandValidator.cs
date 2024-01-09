using FluentValidation;

namespace Application.Features.EducationPaths.Commands.Create;

public class CreateEducationPathCommandValidator : AbstractValidator<CreateEducationPathCommand>
{
    public CreateEducationPathCommandValidator()
    {
        RuleFor(c => c.EducationAdmirationId).NotEmpty();
        RuleFor(c => c.EducationAboutId).NotEmpty();
        RuleFor(c => c.TimeSpentId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
    }
}