using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProfileSkills.Commands.Delete.DeleteSkillByUserId;
public class DeleteSkillByUserIdResponse : IResponse
{
    public int UserProfileId { get; set; }
    public int SkillId { get; set; }
}
