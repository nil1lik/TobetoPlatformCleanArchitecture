using Core.Application.Responses;

namespace Application.Features.Classes.Commands.Create;

public class CreatedClassResponse : IResponse
{
    public int Id { get; set; }
    public int ProfileAnnouncementId { get; set; }
    public string Name { get; set; }
}