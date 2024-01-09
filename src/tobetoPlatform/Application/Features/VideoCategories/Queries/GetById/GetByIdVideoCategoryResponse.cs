using Core.Application.Responses;

namespace Application.Features.VideoCategories.Queries.GetById;

public class GetByIdVideoCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}