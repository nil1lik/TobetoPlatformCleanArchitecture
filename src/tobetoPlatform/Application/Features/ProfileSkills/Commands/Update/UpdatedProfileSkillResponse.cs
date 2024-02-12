using Core.Application.Responses;

namespace Application.Features.ProfileSkills.Commands.Update;

public class UpdatedProfileSkillResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int SkillId { get; set; }
}