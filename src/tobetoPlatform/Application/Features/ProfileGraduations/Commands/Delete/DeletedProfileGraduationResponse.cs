using Core.Application.Responses;

namespace Application.Features.ProfileGraduations.Commands.Delete;

public class DeletedProfileGraduationResponse : IResponse
{
    public int Id { get; set; }
}