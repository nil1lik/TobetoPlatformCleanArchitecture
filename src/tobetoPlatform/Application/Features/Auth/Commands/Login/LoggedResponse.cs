using Core.Application.Responses;
using Core.Security.Enums;
using Core.Security.JWT;

namespace Application.Features.Auth.Commands.Login;

public class LoggedResponse : IResponse
{
    public AccessToken? AccessToken { get; set; }
    public Core.Security.Entities.RefreshToken? RefreshToken { get; set; }
    public AuthenticatorType? RequiredAuthenticatorType { get; set; }

    public string userId { get; set; }

    public LoggedHttpResponse ToHttpResponse() =>
        new() { AccessToken = AccessToken, RequiredAuthenticatorType = RequiredAuthenticatorType, userId = userId };
    public class LoggedHttpResponse
    {
        public string userId { get; set; }
        public AccessToken? AccessToken { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }
    }
}
