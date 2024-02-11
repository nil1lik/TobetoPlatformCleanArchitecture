using Core.Application.Responses;

namespace Application.Features.ProfileGraduations.Queries.GetById;

public class GetByIdProfileGraduationResponse : IResponse
{
    public int Id { get; set; }
    public int GraduationId { get; set; }
    public int UserProfileId { get; set; }
}