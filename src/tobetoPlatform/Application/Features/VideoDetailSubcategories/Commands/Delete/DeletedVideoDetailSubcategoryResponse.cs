using Core.Application.Responses;

namespace Application.Features.VideoDetailSubcategories.Commands.Delete;

public class DeletedVideoDetailSubcategoryResponse : IResponse
{
    public int Id { get; set; }
}