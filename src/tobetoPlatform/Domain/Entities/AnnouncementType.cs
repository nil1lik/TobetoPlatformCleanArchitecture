using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class AnnouncementType : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }


        public AnnouncementType()
        {
        }

        public AnnouncementType(int id, string name):this()
        {
            Id = id;
            Name = name;
        }
    }
}

