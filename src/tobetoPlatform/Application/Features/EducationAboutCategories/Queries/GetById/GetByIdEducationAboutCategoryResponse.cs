using Core.Application.Responses;

namespace Application.Features.EducationAboutCategories.Queries.GetById;

public class GetByIdEducationAboutCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}