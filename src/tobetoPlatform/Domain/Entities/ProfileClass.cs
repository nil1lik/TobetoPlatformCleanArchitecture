using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProfileClass:Entity<int>
{
    public int UserProfileId { get; set; }
    public int CourseClassId { get; set; }

    public virtual UserProfile UserProfile { get; set; }
    public virtual CourseClass CourseClass { get; set; }

    public ProfileClass()
    {
    }

    public ProfileClass(int id ,int userProfileId, int courseClassId) : this()
    {
        Id = id;
        UserProfileId = userProfileId;
        CourseClassId = courseClassId;
    }

    
}