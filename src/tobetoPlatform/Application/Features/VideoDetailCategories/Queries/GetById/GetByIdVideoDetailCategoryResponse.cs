using Core.Application.Responses;

namespace Application.Features.VideoDetailCategories.Queries.GetById;

public class GetByIdVideoDetailCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}