using Core.Application.Responses;

namespace Application.Features.LessonTypes.Queries.GetById;

public class GetByIdLessonTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}