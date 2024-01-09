using Core.Application.Responses;

namespace Application.Features.Announcements.Commands.Create;

public class CreatedAnnouncementResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsRead { get; set; }
}