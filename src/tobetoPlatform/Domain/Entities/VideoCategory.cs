using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class VideoCategory : Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<AsyncLesson> AsyncLessons { get; set; }

    public VideoCategory()
    {

    }

    public VideoCategory(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}
