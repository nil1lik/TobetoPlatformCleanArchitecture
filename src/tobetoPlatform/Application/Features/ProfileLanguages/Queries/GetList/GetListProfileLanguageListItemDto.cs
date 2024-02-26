using Core.Application.Dtos;

namespace Application.Features.ProfileLanguages.Queries.GetList;

public class GetListProfileLanguageListItemDto : IDto
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int LanguageId { get; set; }
    public int LanguageLevelId { get; set; }
}