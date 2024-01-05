using Core.Application.Responses;

namespace Application.Features.Certificates.Commands.Update;

public class UpdatedCertificateResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public string Name { get; set; }
    public string FileUrl { get; set; }
    public string FileType { get; set; }
}