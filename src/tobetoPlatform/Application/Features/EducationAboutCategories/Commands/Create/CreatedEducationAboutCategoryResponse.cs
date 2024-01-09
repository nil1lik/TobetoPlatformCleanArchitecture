using Core.Application.Responses;

namespace Application.Features.EducationAboutCategories.Commands.Create;

public class CreatedEducationAboutCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}