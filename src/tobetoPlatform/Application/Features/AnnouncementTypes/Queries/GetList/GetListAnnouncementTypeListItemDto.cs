using Core.Application.Dtos;

namespace Application.Features.AnnouncementTypes.Queries.GetList;

public class GetListAnnouncementTypeListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}