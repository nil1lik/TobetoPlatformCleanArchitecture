using Core.Application.Responses;

namespace Application.Features.ProfileExams.Commands.Delete;

public class DeletedProfileExamResponse : IResponse
{
    public int Id { get; set; }
}