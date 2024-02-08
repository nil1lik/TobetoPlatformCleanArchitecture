using Core.Application.Responses;

namespace Application.Features.VideoDetailCategories.Commands.Update;

public class UpdatedVideoDetailCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}