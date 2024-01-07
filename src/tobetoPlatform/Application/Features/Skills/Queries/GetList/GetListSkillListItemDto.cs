using Core.Application.Dtos;

namespace Application.Features.Skills.Queries.GetList;

public class GetListSkillListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}