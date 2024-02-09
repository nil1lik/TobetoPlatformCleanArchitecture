using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EducationAbouts.Queries.EducationAboutDetailById;
public class GetByIdEducationAboutDetailDto:IResponse
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string CategoryName { get; set; }
    public string CompanyName { get; set; }
}
