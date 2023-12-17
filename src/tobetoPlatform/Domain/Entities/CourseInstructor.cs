using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CourseInstructor : Entity<int>
{
    public virtual ICollection<Course> Courses { get; set; }
    public virtual ICollection<Instructor> Instructors { get; set; }
}