namespace Application.Features.Users.Commands.UpdatePassword
{
    public class PasswordUpdatedResponse
    {
        public int UserId { get; set; }
        public bool IsPasswordUpdated { get; set; }
    }
}
