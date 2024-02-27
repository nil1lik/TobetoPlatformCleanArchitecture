using Core.Application.Responses;

namespace Application.Features.ProfileEducations.Commands.Update;

public class UpdatedProfileEducationResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int EducationPathId { get; set; }
}