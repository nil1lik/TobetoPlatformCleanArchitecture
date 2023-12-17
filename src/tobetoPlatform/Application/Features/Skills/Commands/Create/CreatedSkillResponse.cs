using Core.Application.Responses;

namespace Application.Features.Skills.Commands.Create;

public class CreatedSkillResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}