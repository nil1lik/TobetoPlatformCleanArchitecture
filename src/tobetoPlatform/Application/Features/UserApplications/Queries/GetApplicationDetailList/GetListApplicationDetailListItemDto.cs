using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserApplications.Queries.GetApplicationDetailList;
public class GetListApplicationDetailListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> ApplicationStepName { get; set; }
}
