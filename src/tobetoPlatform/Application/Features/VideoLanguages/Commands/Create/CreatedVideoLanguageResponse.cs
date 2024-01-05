using Core.Application.Responses;

namespace Application.Features.VideoLanguages.Commands.Create;

public class CreatedVideoLanguageResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}