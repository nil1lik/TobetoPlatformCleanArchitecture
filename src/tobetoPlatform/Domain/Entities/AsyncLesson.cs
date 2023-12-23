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
    public int ProfileEducationId { get; set; }
    public int LessonVideoDetailId { get; set; }
    public int VideoCategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TimeSpan Time { get; set; }
    public string VideoUrl { get; set; }

    //Lesson'a ait point nerde?

    public virtual LessonVideoDetail LessonVideoDetail { get; set; }
    public virtual ICollection<CourseLesson> CourseLessons { get; set; }
    public virtual VideoCategory VideoCategory { get; set; }

    public virtual ProfileEducation ProfileEducation { get; set; }

    public AsyncLesson()
    {

    }

    public AsyncLesson(int id, int profileEducationId, int lessonVideoDetailId, string name, string description, string videoUrl, int videoCategoryId) : this()
    {
        Id = id;
        ProfileEducationId = profileEducationId;
        LessonVideoDetailId = lessonVideoDetailId;
        Name = name;
        Description = description;
        VideoUrl = videoUrl;
        VideoCategoryId = videoCategoryId;
    }
}
