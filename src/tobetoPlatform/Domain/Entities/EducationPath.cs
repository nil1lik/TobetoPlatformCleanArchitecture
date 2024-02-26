using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class EducationPath : Entity<int>
{
    public int EducationAdmirationId { get; set; }
    public int EducationAboutId { get; set; }

    public string Name { get; set; }
    public string ImageUrl { get; set; }

    public virtual EducationAbout EducationAbout { get; set; }
    public virtual EducationAdmiration EducationAdmiration { get; set; }

    public virtual ICollection<ProfileEducation> ProfileEducations { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
    public virtual ICollection<Calendar> Calendars { get; set; }

    public EducationPath()
    {

    }

    public EducationPath(int id,int educationAboutId, int educationAdmirationId, string name, string imageUrl) : this()
    {
        Id = id;
        EducationAdmirationId = educationAdmirationId;
        EducationAboutId = educationAboutId;
        Name = name;
        ImageUrl = imageUrl;
    }
}
