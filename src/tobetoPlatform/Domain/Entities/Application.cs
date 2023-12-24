using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Application : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<ProfileApplication> ProfileApplications { get; set; }
        public virtual ICollection<ApplicationStep> ApplicationSteps { get; set; }


        public Application()
        {
        }

        public Application(int id,string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}

