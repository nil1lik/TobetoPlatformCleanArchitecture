using Application.Features.Users.Rules;
using Application.Features.Users.Constants;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Application.Features.Users.Commands.UpdateFromAuth;
using Application.Services.AuthService;

namespace Application.Features.Users.Commands.UpdatePassword
{
    public class UpdatePasswordCommand : IRequest<PasswordUpdatedResponse>
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string? NewPassword { get; set; }

        public UpdatePasswordCommand(int id, string password, string? newPassword)
        {
            Id = id;
            Password = password;
            NewPassword = newPassword;
        }

        public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, PasswordUpdatedResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IAuthService _authService;

            public UpdatePasswordCommandHandler(
                IUserRepository userRepository,
                IMapper mapper,
                UserBusinessRules userBusinessRules,
                IAuthService authService
            )
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _authService = authService;
            }

            public async Task<PasswordUpdatedResponse> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(predicate: u => u.Id == request.Id, cancellationToken: cancellationToken);
                await _userBusinessRules.UserShouldBeExistsWhenSelected(user);

                user = _mapper.Map(request, user);
                if (request.NewPassword != null && !string.IsNullOrWhiteSpace(request.NewPassword))
                {
                    HashingHelper.CreatePasswordHash(
                        request.Password,
                        passwordHash: out byte[] passwordHash,
                        passwordSalt: out byte[] passwordSalt
                    );
                    user!.PasswordHash = passwordHash;
                    user!.PasswordSalt = passwordSalt;
                }
                User updatedPassword = await _userRepository.UpdateAsync(user!);

                PasswordUpdatedResponse response = _mapper.Map<PasswordUpdatedResponse>(updatedPassword);
                return response;
            }
        }
    }
}