using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserApplications.Queries.GetApplicationDetail;
public class GetApplicationDetailResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ApplicationStepName { get; set; }
}
