using Core.Application.Responses;

namespace Application.Features.Graduations.Commands.Delete;

public class DeletedGraduationResponse : IResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}