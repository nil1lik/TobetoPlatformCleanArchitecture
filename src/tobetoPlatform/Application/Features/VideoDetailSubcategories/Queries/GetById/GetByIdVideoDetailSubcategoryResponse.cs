using Core.Application.Responses;

namespace Application.Features.VideoDetailSubcategories.Queries.GetById;

public class GetByIdVideoDetailSubcategoryResponse : IResponse
{
    public int Id { get; set; }
    public int VideoDetailCategoryId { get; set; }
    public string Name { get; set; }
}