using Core.Application.Responses;

namespace Application.Features.ProfileEducations.Commands.Delete;

public class DeletedProfileEducationResponse : IResponse
{
    public int Id { get; set; }
}