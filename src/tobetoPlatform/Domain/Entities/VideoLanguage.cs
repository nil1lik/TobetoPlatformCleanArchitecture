using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class VideoLanguage : Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<LessonVideoDetail> LessonVideoDetails { get; set; }

    public VideoLanguage()
    {

    }

    public VideoLanguage(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}