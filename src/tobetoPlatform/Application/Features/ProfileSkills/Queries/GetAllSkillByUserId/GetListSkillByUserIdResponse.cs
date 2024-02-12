using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProfileSkills.Queries.GetAllSkillByUserId;
public class GetListSkillByUserIdResponse :IResponse
{
    public int UserId { get; set; }
    public string SkillName { get; set; }
}
