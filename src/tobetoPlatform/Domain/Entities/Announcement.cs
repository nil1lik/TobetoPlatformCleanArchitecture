using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Announcement : Entity<int>
    {
        public int AnnouncementTypeId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public bool IsRead { get; set; }

        public virtual AnnouncementType AnnouncementType { get; set; }
        public virtual ICollection<ProfileAnnouncement>? ProfileAnnouncement { get; set; }

        public Announcement()
        {
            
        }

        public Announcement(int id,int announcementTypeId, string name, string title, string description, bool isRead):this()
        {
            Id = id;
            AnnouncementTypeId = announcementTypeId;
            Name = name;
            Title = title;
            Description = description;
            IsRead = isRead;
        }
    }
}
