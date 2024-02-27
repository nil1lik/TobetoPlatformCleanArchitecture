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
    public int CourseClassId { get; set; }
    public string Name { get; set; }
    public TimeSpan Time { get; set; }
    public double VideoPoint {  get; set; }  
    public string VideoUrl { get; set; }
    public bool IsCompleted { get; set; }

    public virtual LessonVideoDetail LessonVideoDetail { get; set; }
    public virtual VideoCategory VideoCategory { get; set; }
    public virtual CourseClass CourseClass { get; set; }

    public virtual LessonType LessonType { get; set; }

    public virtual ICollection<CourseLesson> CourseLessons { get; set; }

    public AsyncLesson()
    {

    }

    public AsyncLesson(int id, bool isCompleted,int lessonTypeId,int courseClassId, double videoPoint, TimeSpan time, int lessonVideoDetailId, string name, string videoUrl, int videoCategoryId) : this()
    {
        Id = id;
        LessonVideoDetailId = lessonVideoDetailId;
        CourseClassId = courseClassId;
        IsCompleted = isCompleted;
        Name = name;
        LessonTypeId = lessonTypeId;
        VideoUrl = videoUrl;
        Time = time;
        VideoPoint = videoPoint;
        VideoCategoryId = videoCategoryId;
    }
}
