using Core.Application.Dtos;

namespace Application.Features.VideoDetailCategories.Queries.GetList;

public class GetListVideoDetailCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}