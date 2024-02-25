using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProfileLanguages.Commands.Delete.DeleteLanguageByUserId;
public class DeleteLanguageByUserIdResponse : IResponse
{
    public int UserProfileId { get; set; }
    public int LanguageId { get; set; }
    public int LanguageLevelId { get; set; }
}
