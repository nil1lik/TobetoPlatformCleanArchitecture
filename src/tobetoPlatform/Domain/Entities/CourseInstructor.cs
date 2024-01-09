using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CourseInstructor : Entity<int>
{
    public int CourseId { get; set; }
    public int InstructorId { get; set; }

    public virtual Course Course { get; set; }
    public virtual Instructor Instructor { get; set; }

    public CourseInstructor()
    {
    }

    public CourseInstructor(int id, int courseId, int instructorId) : this()
    {
        Id = id;
        CourseId = courseId;
        InstructorId = instructorId;
    }

    
}