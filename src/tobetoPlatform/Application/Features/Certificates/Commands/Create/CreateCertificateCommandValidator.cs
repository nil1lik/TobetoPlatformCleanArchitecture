using FluentValidation;

namespace Application.Features.Certificates.Commands.Create;

public class CreateCertificateCommandValidator : AbstractValidator<CreateCertificateCommand>
{
    public CreateCertificateCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.FileUrl).NotEmpty();
        RuleFor(c => c.FileType).NotEmpty();
    }
}