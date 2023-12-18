using Core.Application.Responses;

namespace Application.Features.EducationAboutCategories.Commands.Update;

public class UpdatedEducationAboutCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}