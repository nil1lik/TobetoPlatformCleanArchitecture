using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class SocialMediaAccount : Entity<int>  
{
    public int UserProfileId { get; set; }
    public int SocialMediaCategoryId { get; set; }
    public string Name { get; set; }
    public string MediaUrl { get; set; }

    public virtual UserProfile UserProfile { get; set; }
    public virtual SocialMediaCategory SocialMediaCategory { get; set; }

    public SocialMediaAccount()
    {

    }

    public SocialMediaAccount(int userProfileId, int socialMediaCategoryId, string name, string mediaUrl, int id) : this()
    {
        Id = id;
        UserProfileId = userProfileId;
        SocialMediaCategoryId = socialMediaCategoryId;
        Name = name;
        MediaUrl = mediaUrl;
    }
}

