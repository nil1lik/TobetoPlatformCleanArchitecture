using Core.Application.Responses;

namespace Application.Features.EducationAboutCategories.Commands.Delete;

public class DeletedEducationAboutCategoryResponse : IResponse
{
    public int Id { get; set; }
}