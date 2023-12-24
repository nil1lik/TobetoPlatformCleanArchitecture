using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class SocialMediaCategory : Entity<int>  
    {
        public string Name { get; set; }

        public virtual ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }

        public SocialMediaCategory()
        {
        }

        public SocialMediaCategory(int id ,string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}

