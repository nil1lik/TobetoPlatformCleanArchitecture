using Core.Application.Responses;

namespace Application.Features.VideoLanguages.Queries.GetById;

public class GetByIdVideoLanguageResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}