using Core.Application.Dtos;

namespace Application.Features.EducationAboutCategories.Queries.GetList;

public class GetListEducationAboutCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}