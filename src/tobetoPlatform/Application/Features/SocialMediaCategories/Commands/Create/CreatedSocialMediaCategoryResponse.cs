using Core.Application.Responses;

namespace Application.Features.SocialMediaCategories.Commands.Create;

public class CreatedSocialMediaCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}