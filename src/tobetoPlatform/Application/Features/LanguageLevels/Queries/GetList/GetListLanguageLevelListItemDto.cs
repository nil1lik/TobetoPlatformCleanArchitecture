using Core.Application.Dtos;

namespace Application.Features.LanguageLevels.Queries.GetList;

public class GetListLanguageLevelListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}