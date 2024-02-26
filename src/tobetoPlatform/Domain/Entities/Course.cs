using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Course : Entity<int>
{
    public int EducationPathId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }

    public virtual EducationPath EducationPath { get; set; }

    public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
    public virtual ICollection<SyncLesson> SyncLessons { get; set; }
    public virtual ICollection<CourseLesson> CourseLesson { get; set; }

    public Course()
    {

    }

    public Course(int id, int educationPathId,  string name, string imageUrl) : this()
    {
        Id = id;
        EducationPathId = educationPathId;
        Name = name;
        ImageUrl = imageUrl;
    }
}
