using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class UserApplication : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<ProfileApplication> ProfileApplications { get; set; }
        public virtual ICollection<ApplicationStep> ApplicationSteps { get; set; }


        public UserApplication()
        {
        }

        public UserApplication(int id,string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}

