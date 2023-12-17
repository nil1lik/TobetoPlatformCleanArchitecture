using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProfileClass:Entity<int>
{
    public int ProfileAnnouncementId { get; set; }
    public virtual ProfileAnnouncement ProfileAnnouncement { get; set; }

    public ProfileClass()
    {
        
    }

    public ProfileClass(int id, int profileAnnouncementId):this()
    {
        Id = id;
        ProfileAnnouncementId = profileAnnouncementId;
    }
}