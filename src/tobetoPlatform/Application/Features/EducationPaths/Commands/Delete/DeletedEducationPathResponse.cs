using Core.Application.Responses;

namespace Application.Features.EducationPaths.Commands.Delete;

public class DeletedEducationPathResponse : IResponse
{
    public int Id { get; set; }
}