using Core.Application.Responses;

namespace Application.Features.Surveys.Commands.Create;

public class CreatedSurveyResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}