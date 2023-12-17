using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProfileAnnouncement:Entity<int>
{
    public virtual ICollection<ProfileClass> ProfileClasses { get; set; }
    public virtual ICollection<Profile> Profiles { get; set; }
    public virtual ICollection<Announcement> Announcements { get; set; }
}
