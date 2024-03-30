using Core.Application.Dtos;

namespace Application.Features.ProfileAdmirations.Queries.GetList;

public class GetListProfileAdmirationListItemDto : IDto
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int EducationAdmirationId { get; set; }
    public int EducationPathId { get; set; }
}