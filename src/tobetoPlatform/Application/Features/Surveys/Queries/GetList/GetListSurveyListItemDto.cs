using Core.Application.Dtos;

namespace Application.Features.Surveys.Queries.GetList;

public class GetListSurveyListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}