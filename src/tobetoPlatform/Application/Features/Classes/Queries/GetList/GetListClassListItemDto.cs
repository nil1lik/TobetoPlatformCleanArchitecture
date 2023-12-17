using Core.Application.Dtos;

namespace Application.Features.Classes.Queries.GetList;

public class GetListClassListItemDto : IDto
{
    public int Id { get; set; }
    public int ProfileAnnouncementId { get; set; }
    public string Name { get; set; }
}