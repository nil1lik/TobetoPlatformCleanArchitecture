using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProfileClass:Entity<int>
{
    public virtual ICollection<UserProfile> UserProfiles { get; set; } 
    public virtual ICollection<CourseClass> CourseClasses { get; set; }
}