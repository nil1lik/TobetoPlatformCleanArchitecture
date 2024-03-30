using Core.Application.Responses;
using System;
namespace Application.Features.UserProfiles.Queries.GetAsyncsLessonByUserId
{
    public class GetAllAsyncLessonsByUserIdResponse : IResponse
    {
        public int UserProfileId { get; set; }
        public List<AsyncLessonItem> AsyncLessonItem { get; set; }
    }
    public class AsyncLessonItem
    {
        public int Id { get; set; }
        public int AsyncLessonId { get; set; }
        public bool IsWatched { get; set; }
    }


}


