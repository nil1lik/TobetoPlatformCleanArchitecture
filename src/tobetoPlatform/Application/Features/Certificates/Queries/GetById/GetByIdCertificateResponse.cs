using Core.Application.Responses;

namespace Application.Features.Certificates.Queries.GetById;

public class GetByIdCertificateResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FileUrl { get; set; }
    public string FileType { get; set; }
}