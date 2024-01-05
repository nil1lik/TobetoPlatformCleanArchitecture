using Core.Application.Responses;

namespace Application.Features.SocialMediaCategories.Queries.GetById;

public class GetByIdSocialMediaCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}