using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Instructor : Entity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    
    //CourseInstructor buraya yazılmalı mı?
    public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }

    public Instructor()
    {

    }

    public Instructor(int id, string firstName, string lastName, string imageUrl) : this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        ImageUrl = imageUrl;
    }
}