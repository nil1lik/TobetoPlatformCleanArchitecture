using Core.Application.Responses;
using System;
namespace Application.Features.SyncLessons.Queries.GetLessonDetailBySyncLessonId
{
    public class GetLessonDetailBySyncLessonIdResponse : IResponse
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


