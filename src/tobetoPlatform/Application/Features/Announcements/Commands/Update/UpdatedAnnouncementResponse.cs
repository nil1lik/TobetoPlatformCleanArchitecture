using Core.Application.Responses;

namespace Application.Features.Announcements.Commands.Update;

public class UpdatedAnnouncementResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}