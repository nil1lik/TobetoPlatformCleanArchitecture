using Core.Application.Responses;

namespace Application.Features.ProfileAdmirations.Commands.Create;

public class CreatedProfileAdmirationResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int EducationAdmirationId { get; set; }
    public int EducationPathId { get; set; }
}