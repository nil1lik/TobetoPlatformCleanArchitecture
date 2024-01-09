using Core.Application.Responses;

namespace Application.Features.EducationAbouts.Commands.Delete;

public class DeletedEducationAboutResponse : IResponse
{
    public int Id { get; set; }
}