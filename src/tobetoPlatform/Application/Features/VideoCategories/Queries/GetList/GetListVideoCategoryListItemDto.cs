using Core.Application.Dtos;

namespace Application.Features.VideoCategories.Queries.GetList;

public class GetListVideoCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}