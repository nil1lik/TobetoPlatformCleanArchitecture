using Core.Application.Responses;

namespace Application.Features.VideoCategories.Commands.Delete;

public class DeletedVideoCategoryResponse : IResponse
{
    public int Id { get; set; }
}