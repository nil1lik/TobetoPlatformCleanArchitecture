using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileLesson : Entity<int>
    {
        public int UserProfileId { get; set; }
        public int AsyncLessonId { get; set; }
        public bool IsWatched { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual AsyncLesson AsyncLesson { get; set; }

        public ProfileLesson()
        {
        }

        public ProfileLesson(int id, int userProfileId, int asyncLessonId, bool isWatched) : this()
        {
            Id = id;
            UserProfileId = userProfileId;
            AsyncLessonId = asyncLessonId;
            IsWatched = isWatched;
        }
    }
}


