using Core.Application.Responses;

namespace Application.Features.EducationAdmirations.Commands.Delete;

public class DeletedEducationAdmirationResponse : IResponse
{
    public int Id { get; set; }
}