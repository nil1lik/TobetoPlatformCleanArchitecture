using Core.Application.Responses;

namespace Application.Features.LessonTypes.Commands.Create;

public class CreatedLessonTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}