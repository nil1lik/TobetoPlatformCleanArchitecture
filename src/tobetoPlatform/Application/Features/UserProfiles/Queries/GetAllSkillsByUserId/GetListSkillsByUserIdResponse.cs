using Core.Application.Dtos;
using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetAllSkillByUserId;
public class GetListSkillsByUserIdResponse : IResponse
{
    public int UserProfileId { get; set; }

    public List<SkillDto> SkillDtoItems { get; set; }

}

public class SkillDto : IDto
{
    public int SkillId { get; set; }
    public string SkillName { get; set; }
}


