using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProfileClass:Entity<int>
{
    public virtual ICollection<Profile> Profiles { get; set; } 
    public virtual ICollection<CourseClass> CourseClasses { get; set; }
}