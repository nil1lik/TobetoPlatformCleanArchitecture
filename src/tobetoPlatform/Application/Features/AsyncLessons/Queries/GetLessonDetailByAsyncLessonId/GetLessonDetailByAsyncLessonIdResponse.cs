using Core.Application.Responses;
using Domain.Entities;
using System;
namespace Application.Features.AsyncLessons.Queries.GetLessonDetailByAsyncLessonId
{
    public class GetLessonDetailByAsyncLessonIdResponse : IResponse
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public double VideoPoint { get; set; }
        public string VideoUrl { get; set; }
        public string LessonTypeName { get; set; }
        public string LanguageName { get; set; } 
        public string CompanyName { get; set; }
        public string SubcategoryName  { get; set; }
        public string VideoDetailCategoryName { get; set; }

        //public List<VideoDetailCategory> VideoDetailCategories { get; set; } 
    } 
}



