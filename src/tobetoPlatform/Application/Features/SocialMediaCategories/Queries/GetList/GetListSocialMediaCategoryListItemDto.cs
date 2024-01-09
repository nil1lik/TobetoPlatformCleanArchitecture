using Core.Application.Dtos;

namespace Application.Features.SocialMediaCategories.Queries.GetList;

public class GetListSocialMediaCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}