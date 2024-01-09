using Core.Application.Responses;

namespace Application.Features.SocialMediaCategories.Commands.Delete;

public class DeletedSocialMediaCategoryResponse : IResponse
{
    public int Id { get; set; }
}