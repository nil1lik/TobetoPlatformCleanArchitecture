using FluentValidation;

namespace Application.Features.ProfileExams.Commands.Create;

public class CreateProfileExamCommandValidator : AbstractValidator<CreateProfileExamCommand>
{
    public CreateProfileExamCommandValidator()
    {
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.ExamId).NotEmpty();
    }
}