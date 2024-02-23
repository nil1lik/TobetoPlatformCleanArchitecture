using Core.Application.Dtos;

namespace Application.Features.ProfileSkills.Queries.GetList;

public class GetListProfileSkillListItemDto : IDto
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
}