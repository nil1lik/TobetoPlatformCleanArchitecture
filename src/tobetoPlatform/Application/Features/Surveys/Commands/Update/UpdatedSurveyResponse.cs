using Core.Application.Responses;

namespace Application.Features.Surveys.Commands.Update;

public class UpdatedSurveyResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}