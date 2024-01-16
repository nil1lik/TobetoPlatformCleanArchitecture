using FluentValidation;

namespace Application.Features.ProfileExams.Commands.Delete;

public class DeleteProfileExamCommandValidator : AbstractValidator<DeleteProfileExamCommand>
{
    public DeleteProfileExamCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}