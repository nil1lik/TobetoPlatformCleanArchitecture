using Core.Application.Responses;

namespace Application.Features.LessonTypes.Commands.Update;

public class UpdatedLessonTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}