using FluentValidation;

namespace Application.Features.ProfileAddresses.Commands.Create;

public class CreateProfileAddressCommandValidator : AbstractValidator<CreateProfileAddressCommand>
{
    public CreateProfileAddressCommandValidator()
    {
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.CountryId).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.DistrictId).NotEmpty();
        RuleFor(c => c.AddressDetail).NotEmpty();
    }
}