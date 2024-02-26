using Core.Application.Responses;

namespace Application.Features.VideoDetailCategories.Commands.Delete;

public class DeletedVideoDetailCategoryResponse : IResponse
{
    public int Id { get; set; }
}