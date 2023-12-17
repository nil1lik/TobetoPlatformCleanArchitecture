using Core.Application.Responses;

namespace Application.Features.LanguageLevels.Commands.Create;

public class CreatedLanguageLevelResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}