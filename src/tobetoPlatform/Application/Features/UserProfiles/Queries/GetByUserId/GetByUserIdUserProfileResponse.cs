using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetByUserId;
public class GetByUserIdUserProfileResponse :IResponse
{
    public int UserId { get; set; }
}
