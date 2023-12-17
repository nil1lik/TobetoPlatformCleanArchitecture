using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class SocialMediaCategory : Entity<int>  //güncellendi
    {
        public string Name { get; set; }

        public SocialMediaCategory()
        {
        }
    }
}

