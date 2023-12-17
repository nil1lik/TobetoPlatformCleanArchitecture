using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class VideoDetailSubcategory:Entity<int>
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public virtual VideoDetailCategory Categories { get; set; }
    public virtual ICollection<LessonVideoDetail> LessonVideoDetails { get; set; }

    public VideoDetailSubcategory()
    {
        
    }
}

