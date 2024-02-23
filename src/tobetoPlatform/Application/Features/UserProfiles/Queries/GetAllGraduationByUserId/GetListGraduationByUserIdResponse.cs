using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetAllGraduationByUserId;
public class GetListGraduationByUserIdResponse
{
    public int UserProfileId { get; set; }

    public List<GraduationDto> GraduationsDtoItems { get; set; }
}

public class GraduationDto
{
    public int Id { get; set; }
    public string Degree { get; set; }
    public string UniversityName { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime GraduationDate { get; set; }
}