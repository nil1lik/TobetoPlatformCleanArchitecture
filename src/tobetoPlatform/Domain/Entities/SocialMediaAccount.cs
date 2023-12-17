using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class SocialMediaAccount : Entity<int>  //güncellendi
{
    public string Name { get; set; }
    public string MediaUrl { get; set; }

    public SocialMediaAccount()
    {

    }

    public SocialMediaAccount(string name, string mediaUrl, int id) : this()
    {
        Id = id;
        Name = name;
        MediaUrl = mediaUrl;
    }
}
