using Application.Features.UserProfiles.Queries.GetAllEducationsByUserId;
using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetAllCertificatesByUserId;
public class GetAllCertificatesByUserIdResponse:IResponse
{
    public int UserProfileId { get; set; }
    public List<CertificateDtoItems> CertificateDtoItems { get; set; }

}

public class CertificateDtoItems
{
    public int Id { get; set; }
    public int CertificateId { get; set; }
    public string CertificateName { get; set; }
    public string CertificateFileUrl { get; set; }
    public string CertificateFileType{ get; set; }

}
