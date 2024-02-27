using Core.Application.Responses;

namespace Application.Features.ProfileEducations.Commands.Create;

public class CreatedProfileEducationResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int EducationPathId { get; set; }
}