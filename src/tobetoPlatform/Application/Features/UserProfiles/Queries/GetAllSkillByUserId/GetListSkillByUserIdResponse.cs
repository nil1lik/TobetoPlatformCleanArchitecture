using Core.Application.Dtos;
using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetAllSkillByUserId;
public class GetListSkillByUserIdResponse : IResponse
{
    public int UserProfileId { get; set; }
    public List<int> SkillId { get; set; }
    public List<string> SkillName { get; set; }

}


