using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CourseLesson : Entity<int>
{
    public int CourseId { get; set; }
    public int AsyncLessonId { get; set; }

    public virtual Course Course { get; set; }
    public virtual AsyncLesson AsyncLesson { get; set; }

    public CourseLesson()
    {
    }

    public CourseLesson(int id ,int courseId, int asyncLessonId) : this()
    {
        Id = id;
        CourseId = courseId;
        AsyncLessonId = asyncLessonId;
    }

    

}