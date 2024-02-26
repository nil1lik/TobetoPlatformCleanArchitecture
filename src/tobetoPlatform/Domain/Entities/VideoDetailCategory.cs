using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class VideoDetailCategory:Entity<int>
{
    public string Name { get; set; }


    public virtual ICollection<VideoDetailSubcategory> VideoDetailSubcategories { get; set; }
    public virtual ICollection<LessonVideoDetailVideoDetailCategory> LessonVideoDetailVideoDetailCategories { get; set; }

    public VideoDetailCategory()
    {

    }

    public VideoDetailCategory(int id, string name) : this()
    {
        Id = id;
        Name = name; 
    }
}