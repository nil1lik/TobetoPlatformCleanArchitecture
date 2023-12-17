using Core.Application.Responses;

namespace Application.Features.LanguageLevels.Commands.Delete;

public class DeletedLanguageLevelResponse : IResponse
{
    public int Id { get; set; }
}