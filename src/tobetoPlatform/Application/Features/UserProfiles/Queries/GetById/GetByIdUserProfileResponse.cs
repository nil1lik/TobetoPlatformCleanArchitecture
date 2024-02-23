using Core.Application.Responses;
using System.Reflection.Metadata.Ecma335;

namespace Application.Features.UserProfiles.Queries.GetById;

public class GetByIdUserProfileResponse : IResponse
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Description { get; set; }
}