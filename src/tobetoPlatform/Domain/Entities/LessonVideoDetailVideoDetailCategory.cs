using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class LessonVideoDetailVideoDetailCategory : Entity<int>
    {
        public int LessonVideoDetailId { get; set; }
        public int VideoDetailCategoryId { get; set; }

        public virtual LessonVideoDetail LessonVideoDetail { get; set; }
        public virtual VideoDetailCategory VideoDetailCategory { get; set; }

        public LessonVideoDetailVideoDetailCategory()
        {
        }

        public LessonVideoDetailVideoDetailCategory(int id, int lessonVideoDetailId, int videoDetailCategoryId): this()
        {
            Id = id;
            LessonVideoDetailId = lessonVideoDetailId;
            VideoDetailCategoryId = videoDetailCategoryId;
        }

        
    }
}

