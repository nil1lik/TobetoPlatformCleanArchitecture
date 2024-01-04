using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class LessonType:Entity<int>
{
    public string Name { get; set; }

    public LessonType()
    {
        
    }

    public LessonType(int id, string name):this()
    {
        Id = id;
        Name = name;
    }
}
