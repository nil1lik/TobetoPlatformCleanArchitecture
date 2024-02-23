using Core.Application.Dtos;
using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProfileSkills.Queries.GetAllSkillByUserId;
public class GetListSkillByUserIdResponse :IResponse
{
    public int UserProfileId { get; set; }

    public List<ProfileSkillDto> ProfileSkillItems { get; set; }
}

public class ProfileSkillDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

