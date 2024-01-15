using Core.Application.Responses;

namespace Application.Features.AnnouncementTypes.Queries.GetById;

public class GetByIdAnnouncementTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}