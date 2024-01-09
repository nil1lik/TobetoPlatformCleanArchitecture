using Core.Application.Responses;

namespace Application.Features.Languages.Commands.Create;

public class CreatedLanguageResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LanguageLevelId { get; set; }
}