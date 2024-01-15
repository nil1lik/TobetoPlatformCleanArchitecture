using Core.Application.Responses;

namespace Application.Features.ProfileAddresses.Commands.Create;

public partial class CreatedProfileAddressResponse : IResponse
{
    public int UserProfileId { get; set; }
    public string CountryId { get; set; }
    public string CityId { get; set; }
    public string DistrictId { get; set; }
    public string AddressDetailId { get; set; }
}

