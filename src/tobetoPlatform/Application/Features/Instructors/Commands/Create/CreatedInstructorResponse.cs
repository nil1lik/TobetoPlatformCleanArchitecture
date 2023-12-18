using Core.Application.Responses;

namespace Application.Features.Instructors.Commands.Create;

public class CreatedInstructorResponse : IResponse
{
    public int Id { get; set; }
    public int CourseInstructorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
}