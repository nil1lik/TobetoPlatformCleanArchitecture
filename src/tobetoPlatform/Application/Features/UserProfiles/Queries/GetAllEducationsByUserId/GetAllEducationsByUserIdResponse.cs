using Application.Features.UserProfiles.Queries.GetAllLanguageByUserId;
using Core.Application.Dtos;
using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetAllEducationsByUserId;
public class GetAllEducationsByUserIdResponse:IResponse
{
    public int UserProfileId { get; set; }
    public List<EducationDtoItems> EducationDtoItems { get; set; }
}

public class EducationDtoItems
{
    public int Id { get; set; }
    public int EducationPathId { get; set; }
    public string EducationPathName { get; set; }
    public string EducationPathImageUrl { get; set; }
    public DateTime StartDate { get; set; }
}
