using Core.Application.Responses;

namespace Application.Features.Skills.Commands.Update;

public class UpdatedSkillResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}