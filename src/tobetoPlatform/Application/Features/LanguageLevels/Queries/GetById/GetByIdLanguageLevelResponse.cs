using Core.Application.Responses;

namespace Application.Features.LanguageLevels.Queries.GetById;

public class GetByIdLanguageLevelResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}