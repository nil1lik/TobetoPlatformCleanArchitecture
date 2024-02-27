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
        public string LessonTypeName { get; set; }
        public string SessionName { get; set; }
        public string SyncVideoUrl { get; set; }
        public string SyncVideoName { get; set; }
        public bool IsJoin { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> InstructorNames { get; set; }
    }
}
