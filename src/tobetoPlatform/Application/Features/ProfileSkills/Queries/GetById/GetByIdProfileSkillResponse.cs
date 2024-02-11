using Core.Application.Responses;

namespace Application.Features.ProfileSkills.Queries.GetById;

public class GetByIdProfileSkillResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int SkillId { get; set; }
}