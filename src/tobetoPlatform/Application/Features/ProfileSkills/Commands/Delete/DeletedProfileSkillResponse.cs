using Core.Application.Responses;

namespace Application.Features.ProfileSkills.Commands.Delete;

public class DeletedProfileSkillResponse : IResponse
{
    public int Id { get; set; }
}