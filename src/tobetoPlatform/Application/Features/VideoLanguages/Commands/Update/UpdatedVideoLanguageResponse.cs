using Core.Application.Responses;

namespace Application.Features.VideoLanguages.Commands.Update;

public class UpdatedVideoLanguageResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}