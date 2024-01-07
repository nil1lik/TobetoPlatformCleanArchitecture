using Core.Application.Responses;

namespace Application.Features.VideoCategories.Commands.Create;

public class CreatedVideoCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}