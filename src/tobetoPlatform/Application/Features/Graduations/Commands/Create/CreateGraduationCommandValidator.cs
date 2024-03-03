using FluentValidation;

namespace Application.Features.Graduations.Commands.Create;

public class CreateGraduationCommandValidator : AbstractValidator<CreateGraduationCommand>
{
    public CreateGraduationCommandValidator()
    {
        RuleFor(c => c.Degree).NotEmpty();
        RuleFor(c => c.UniversityName).NotEmpty();
        RuleFor(c => c.Department).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
    }
}