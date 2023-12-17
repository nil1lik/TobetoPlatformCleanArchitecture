using Core.Application.Responses;

namespace Application.Features.Classes.Commands.Update;

public class UpdatedClassResponse : IResponse
{
    public int Id { get; set; }
    public int ProfileAnnouncementId { get; set; }
    public string Name { get; set; }
}