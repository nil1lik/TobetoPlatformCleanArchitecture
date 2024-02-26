using Core.Application.Responses;

namespace Application.Features.ProfileSkills.Commands.Create;

public class CreatedProfileSkillResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int SkillId { get; set; }
}