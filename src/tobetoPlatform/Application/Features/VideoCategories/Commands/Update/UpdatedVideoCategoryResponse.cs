using Core.Application.Responses;

namespace Application.Features.VideoCategories.Commands.Update;

public class UpdatedVideoCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}