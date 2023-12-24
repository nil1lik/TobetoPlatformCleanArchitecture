using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class VideoDetailSubcategory:Entity<int>
{
    public int VideoDetailCategoryId { get; set; }
    public string Name { get; set; }

    public virtual VideoDetailCategory VideoDetailCategory { get; set; }
    public virtual ICollection<LessonVideoDetail> LessonVideoDetails { get; set; }

    public VideoDetailSubcategory()
    {
        
    }

    public VideoDetailSubcategory(int id,int videoDetailCategoryId, string name) : this()
    {
        VideoDetailCategoryId = videoDetailCategoryId;
        Id = id;
        Name = name;
    }
}

