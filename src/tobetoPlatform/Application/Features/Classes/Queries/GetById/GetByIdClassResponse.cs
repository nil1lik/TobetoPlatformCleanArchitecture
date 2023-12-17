using Core.Application.Responses;

namespace Application.Features.Classes.Queries.GetById;

public class GetByIdClassResponse : IResponse
{
    public int Id { get; set; }
    public int ProfileAnnouncementId { get; set; }
    public string Name { get; set; }
}