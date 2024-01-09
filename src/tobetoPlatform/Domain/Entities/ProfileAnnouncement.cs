using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProfileAnnouncement:Entity<int>
{
    public int UserProfileId { get; set; }
    public int AnnouncementId { get; set; }

    public virtual UserProfile UserProfile { get; set; }
    public virtual Announcement Announcement { get; set; }

    public ProfileAnnouncement()
    {
    }

    public ProfileAnnouncement(int id , int userProfileId, int announcementId) : this()
    {
        Id = id;
        UserProfileId = userProfileId;
        AnnouncementId = announcementId;
    }
}
