using Core.Application.Responses;

namespace Application.Features.VideoDetailSubcategories.Commands.Update;

public class UpdatedVideoDetailSubcategoryResponse : IResponse
{
    public int Id { get; set; }
    public int VideoDetailCategoryId { get; set; }
    public string Name { get; set; }
}