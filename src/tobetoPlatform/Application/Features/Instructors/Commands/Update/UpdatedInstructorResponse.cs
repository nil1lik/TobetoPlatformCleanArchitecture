using Core.Application.Responses;

namespace Application.Features.Instructors.Commands.Update;

public class UpdatedInstructorResponse : IResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
}