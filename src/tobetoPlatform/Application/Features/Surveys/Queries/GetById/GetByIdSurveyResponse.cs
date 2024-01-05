using Core.Application.Responses;

namespace Application.Features.Surveys.Queries.GetById;

public class GetByIdSurveyResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}