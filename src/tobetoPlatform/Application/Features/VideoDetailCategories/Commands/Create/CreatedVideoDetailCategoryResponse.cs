using Core.Application.Responses;

namespace Application.Features.VideoDetailCategories.Commands.Create;

public class CreatedVideoDetailCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}