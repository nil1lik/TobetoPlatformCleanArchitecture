using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProfileLanguages.Queries.GetAllLanguageByUserId;
public class GetAllLanguageByUserIdResponse : IResponse
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Level{ get; set; }
}
