using Core.Application.Responses;

namespace Application.Features.LanguageLevels.Commands.Update;

public class UpdatedLanguageLevelResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}