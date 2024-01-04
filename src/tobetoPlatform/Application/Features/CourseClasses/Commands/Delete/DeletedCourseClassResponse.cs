using Core.Application.Responses;

namespace Application.Features.CourseClasses.Commands.Delete;

public class DeletedCourseClassResponse : IResponse
{
    public int Id { get; set; }
}