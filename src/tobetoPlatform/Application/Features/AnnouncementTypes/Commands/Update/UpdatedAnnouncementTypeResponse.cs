using Core.Application.Responses;

namespace Application.Features.AnnouncementTypes.Commands.Update;

public class UpdatedAnnouncementTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}