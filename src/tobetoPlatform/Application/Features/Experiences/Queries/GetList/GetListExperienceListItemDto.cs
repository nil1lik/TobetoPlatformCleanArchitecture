using Core.Application.Dtos;

namespace Application.Features.Experiences.Queries.GetList;

public class GetListExperienceListItemDto : IDto
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int CityId { get; set; }
    public string OrganizationName { get; set; }
    public string Position { get; set; }
    public string Sector { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
}