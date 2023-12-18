using Core.Application.Responses;

namespace Application.Features.Announcements.Queries.GetById;

public class GetByIdAnnouncementResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}