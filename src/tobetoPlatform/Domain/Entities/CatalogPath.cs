using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CatalogPath : Entity<int>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int InstructorId { get; set; }
    public int Time { get; set; }
    public virtual Instructor Instructor { get; set; }

    public CatalogPath()
    {
        
    }

    public CatalogPath(int id,string name, string ımageUrl, int ınstructorId, int time)
    {
        Id = id;
        Name = name;
        ImageUrl = ımageUrl;
        InstructorId = ınstructorId;
        Time = time;
    }
}
