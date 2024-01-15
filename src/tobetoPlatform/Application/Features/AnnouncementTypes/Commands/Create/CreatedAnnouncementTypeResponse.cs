using Core.Application.Responses;

namespace Application.Features.AnnouncementTypes.Commands.Create;

public class CreatedAnnouncementTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}