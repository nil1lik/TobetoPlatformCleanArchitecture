using Core.Application.Responses;

namespace Application.Features.ProfileGraduations.Commands.Update;

public class UpdatedProfileGraduationResponse : IResponse
{
    public int Id { get; set; }
    public int GraduationId { get; set; }
    public int UserProfileId { get; set; }
}