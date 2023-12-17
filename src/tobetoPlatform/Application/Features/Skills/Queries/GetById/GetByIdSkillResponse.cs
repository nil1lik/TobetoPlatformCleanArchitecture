using Core.Application.Responses;

namespace Application.Features.Skills.Queries.GetById;

public class GetByIdSkillResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}