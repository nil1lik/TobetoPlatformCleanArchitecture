using Core.Application.Dtos;
using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetAllLanguageByUserId;
public class GetAllLanguagesByUserIdResponse:IResponse
{
    public int UserProfileId { get; set; }
    public List<LanguageDtoItems> LanguageDtoItems { get; set; }
}

public class LanguageDtoItems: IDto
{
    public int LanguageId { get; set; }
    public int LanguageLevelId { get; set; }
    public string LanguageName { get; set; }
    public string LanguageLevelName { get; set; }
}
