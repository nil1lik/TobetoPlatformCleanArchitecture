using Core.Application.Dtos;

namespace Application.Features.Languages.Queries.GetList;

public class GetListLanguageListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LanguageLevelId { get; set; }
}