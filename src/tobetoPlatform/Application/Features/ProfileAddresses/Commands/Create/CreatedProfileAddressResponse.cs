using Core.Application.Responses;

namespace Application.Features.ProfileAddresses.Commands.Create;

public partial class CreatedProfileAddressResponse : IResponse
{
    public int UserProfileId { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string AddressDetail { get; set; }
}

