using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Announcement:Entity<int>
    {
        public int AnnouncementTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }

        public virtual AnnouncementType AnnouncementType { get; set; }
        public virtual ICollection<ProfileAnnouncement>? ProfileAnnouncement { get; set; }

        public Announcement()
        {

        } 

        public Announcement(string name, bool isRead, string description, int id) : this()
        {
            Id = id;
            Name = name;
            IsRead = isRead;
            Description = description;
        }
    }
}
