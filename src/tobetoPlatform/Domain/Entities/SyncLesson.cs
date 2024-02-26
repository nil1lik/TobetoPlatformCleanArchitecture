using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class SyncLesson : Entity<int>
{
    public int LessonVideoDetailId { get; set; }
    public int CourseId { get; set; }
    public string SyncVideoUrl { get; set; }
    public string SessionName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public bool IsJoin { get; set; }

    public virtual ICollection<Instructor> Instructors { get; set; }
    public virtual ICollection<Calendar> Calendars { get; set; }

    public virtual LessonVideoDetail LessonVideoDetail { get; set; }
    public virtual Course Course { get; set; }

    public SyncLesson()
    {

    }

    public SyncLesson(int id, int lessonVideoDetailId, int courseId, string syncVideoUrl, string sessionName, DateTime startDate, DateTime endDate, bool isJoin):this()
    {
        Id = id;
        LessonVideoDetailId = lessonVideoDetailId;
        CourseId = courseId;
        SyncVideoUrl = syncVideoUrl;
        SessionName = sessionName;
        StartDate = startDate;
        EndDate = endDate;
        IsJoin = isJoin;
    }
}