using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CourseLesson : Entity<int>
{
    public virtual ICollection<Course> Course { get; set; }
    public virtual ICollection<AsyncLesson> AsyncLessons { get; set; }

}