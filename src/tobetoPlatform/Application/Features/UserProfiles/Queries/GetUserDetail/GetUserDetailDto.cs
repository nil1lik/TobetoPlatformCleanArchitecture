using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetUserDetail;
public class GetUserDetailDto : IDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}