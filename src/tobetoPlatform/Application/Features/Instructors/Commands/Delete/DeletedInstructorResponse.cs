using Core.Application.Responses;

namespace Application.Features.Instructors.Commands.Delete;

public class DeletedInstructorResponse : IResponse
{
    public int Id { get; set; }
}