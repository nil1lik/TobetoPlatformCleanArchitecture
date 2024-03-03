using Core.Application.Responses;
using System;
namespace Application.Features.Courses.Queries.GetAsyncLessonsByCourseId
{

    public class GetAsyncLessonsByCourseIdResponse : IResponse
    {
        public List<GetAsyncLessonsByCourseIdItem> AsyncLessons { get; set; }
    }

    public class GetAsyncLessonsByCourseIdItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LessonType { get; set; }
        public TimeSpan Time { get; set; }

    }
}


