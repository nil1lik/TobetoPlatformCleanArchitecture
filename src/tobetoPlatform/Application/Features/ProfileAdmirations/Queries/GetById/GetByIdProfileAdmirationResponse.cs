using Core.Application.Responses;

namespace Application.Features.ProfileAdmirations.Queries.GetById;

public class GetByIdProfileAdmirationResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int EducationAdmirationId { get; set; }
    public int EducationPathId { get; set; }
}