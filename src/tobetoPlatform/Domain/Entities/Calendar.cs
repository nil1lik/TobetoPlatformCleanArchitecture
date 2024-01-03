using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Calendar :Entity<int>
{
    public int SyncLessonId { get; set; }
    public int EducationPathId { get; set; }
    public int InstructorId { get; set; }

    public virtual SyncLesson SyncLesson { get; set; }
    public virtual EducationPath EducationPath { get; set; }
    public virtual Instructor Instructor { get; set; }

    public Calendar()
    {
            
    }

    public Calendar(int id,int syncLessonId, int educationPathId, int instructorId) : this()
    {
        Id = id;
        SyncLessonId = syncLessonId;
        EducationPathId = educationPathId;
        InstructorId = instructorId;
    }
}