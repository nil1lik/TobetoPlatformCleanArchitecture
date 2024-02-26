using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AsyncLesson : Entity<int>
{
    public int LessonVideoDetailId { get; set; }
    public int VideoCategoryId { get; set; }
    public int LessonTypeId { get; set; }
    public string Name { get; set; }
    public TimeSpan Time { get; set; }
    public double VideoPoint {  get; set; } // VideoPoint Async yok
    public string VideoUrl { get; set; }
    public bool IsCompleted { get; set; }

    public virtual LessonVideoDetail LessonVideoDetail { get; set; }
    public virtual VideoCategory VideoCategory { get; set; }
    public virtual LessonType LessonType { get; set; }

    public virtual ICollection<CourseLesson> CourseLessons { get; set; }

    public AsyncLesson()
    {

    }

    public AsyncLesson(int id, bool isCompleted,int lessonTypeId, TimeSpan time, int lessonVideoDetailId, string name, string videoUrl, int videoCategoryId) : this()
    {
        Id = id;
        LessonVideoDetailId = lessonVideoDetailId;
        IsCompleted = isCompleted;
        Name = name;
        LessonTypeId = lessonTypeId;
        VideoUrl = videoUrl;
        Time = time;
        VideoCategoryId = videoCategoryId;
    }
}
