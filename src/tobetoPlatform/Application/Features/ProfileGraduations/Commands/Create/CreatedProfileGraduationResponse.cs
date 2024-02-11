using Core.Application.Responses;

namespace Application.Features.ProfileGraduations.Commands.Create;

public class CreatedProfileGraduationResponse : IResponse
{
    public int Id { get; set; }
    public int GraduationId { get; set; }
    public int UserProfileId { get; set; }
}