using Core.Application.Dtos;
using System;
namespace Application.Features.EducationPaths.Queries.GetCoursesByEducationId
{
    public class GetCoursesByEducationIdDto : IDto
    {
        public int Id { get; set; }
        public List<string> Courses { get; set; }
    }
}

