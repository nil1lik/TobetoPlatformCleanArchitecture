using Core.Application.Responses;
using System;
namespace Application.Features.Courses.Queries.GetSyncLessonsByCourseId
{
    public class GetSyncLessonsByCourseIdResponse : IResponse
    {
        public List<GetSyncLessonsByCourseIdItem> SyncLessons { get; set; }

    }

    public class GetSyncLessonsByCourseIdItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
