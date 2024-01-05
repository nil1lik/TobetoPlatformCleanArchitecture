using Core.Application.Responses;

namespace Application.Features.SocialMediaCategories.Commands.Update;

public class UpdatedSocialMediaCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}