using Core.Application.Dtos;

namespace Application.Features.Announcements.Queries.GetList;

public class GetListAnnouncementListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsRead { get; set; }
}