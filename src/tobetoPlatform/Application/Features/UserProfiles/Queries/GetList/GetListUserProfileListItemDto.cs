using Core.Application.Dtos;

namespace Application.Features.UserProfiles.Queries.GetList;

public class GetListUserProfileListItemDto : IDto
{
    public int Id { get; set; }
    public int ProfileShareId { get; set; }
    public int ProfileAddressId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Description { get; set; }
}