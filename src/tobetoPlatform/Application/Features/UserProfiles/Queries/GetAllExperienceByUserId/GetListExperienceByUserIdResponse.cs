using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetExperienceByUserId;
public class GetListExperienceByUserIdResponse
{
    public int UserProfileId { get; set; }

    public List<ExperienceDto> ExperienceDtoItems { get; set; }
}

public class ExperienceDto
{
    public int Id { get; set; }
    public string CityName { get; set; }
    public string OrganizationName { get; set; }
    public string Position { get; set; }
    public string Sector { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
}
