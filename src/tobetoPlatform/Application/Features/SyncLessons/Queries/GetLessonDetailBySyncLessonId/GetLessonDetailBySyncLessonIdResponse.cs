using Core.Application.Responses;
using System;
namespace Application.Features.SyncLessons.Queries.GetLessonDetailBySyncLessonId
{
    public class GetLessonDetailBySyncLessonIdResponse : IResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LessonTypeName { get; set; }
        public string SubcategoryName { get; set; }
        public string VideoDetailCategoryName { get; set; }
        public string LanguageName { get; set; }
    }
}



