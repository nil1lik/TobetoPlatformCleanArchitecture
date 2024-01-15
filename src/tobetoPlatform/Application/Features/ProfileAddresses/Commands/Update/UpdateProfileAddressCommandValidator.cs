using FluentValidation;

namespace Application.Features.ProfileAddresses.Commands.Update;

public class UpdateProfileAddressCommandValidator : AbstractValidator<UpdateProfileAddressCommand>
{
    public UpdateProfileAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.CountryId).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.DistrictId).NotEmpty();
        RuleFor(c => c.AddressDetail).NotEmpty();
    }
}