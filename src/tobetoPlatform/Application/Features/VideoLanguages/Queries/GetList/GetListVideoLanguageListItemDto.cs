using Core.Application.Dtos;

namespace Application.Features.VideoLanguages.Queries.GetList;

public class GetListVideoLanguageListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}