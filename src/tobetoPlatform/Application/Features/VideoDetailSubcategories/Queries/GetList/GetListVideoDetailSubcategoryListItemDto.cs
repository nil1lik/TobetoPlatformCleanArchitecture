using Core.Application.Dtos;

namespace Application.Features.VideoDetailSubcategories.Queries.GetList;

public class GetListVideoDetailSubcategoryListItemDto : IDto
{
    public int Id { get; set; }
    public int VideoDetailCategoryId { get; set; }
    public string Name { get; set; }
}