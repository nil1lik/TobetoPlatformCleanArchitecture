using Core.Application.Dtos;

namespace Application.Features.ProfileAddresses.Queries.GetList;

public class GetListProfileAddressListItemDto : IDto
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string AddressDetail { get; set; }
}