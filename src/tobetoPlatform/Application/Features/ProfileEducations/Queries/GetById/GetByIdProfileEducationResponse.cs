using Core.Application.Responses;

namespace Application.Features.ProfileEducations.Queries.GetById;

public class GetByIdProfileEducationResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int EducationPathId { get; set; }
}