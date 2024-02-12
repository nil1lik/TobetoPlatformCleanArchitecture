using Core.Application.Responses;
using System;
namespace Application.Features.Courses.Queries.GetAsyncLessonsByCourseId
{
    public class GetAsyncLessonsByCourseIdResponse : IResponse
    {
        public int Id { get; set; }
        public List<string> AsyncLessons { get; set; }

    }
}


