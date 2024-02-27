using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetAllSocialMediaAccountsByUserId;
public class GetListSocialMediaAccountsByUserIdResponse
{
    public int UserProfileId { get; set; }

    public List<SocialMediaAccountDto> SocialMediaAccountsItems { get; set; }
}

public class SocialMediaAccountDto
{
    public int Id { get; set; }
    public int SocialMediaCategoryId { get; set; }
    public string SocialMediaCategoryName { get; set; }
    public string MediaUrl { get; set; }
}
