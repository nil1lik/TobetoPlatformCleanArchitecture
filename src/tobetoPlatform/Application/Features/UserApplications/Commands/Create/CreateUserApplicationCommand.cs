using Application.Features.UserApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserApplications.Commands.Create;

public class CreateUserApplicationCommand : IRequest<CreatedUserApplicationResponse>
{
    public string Name { get; set; }

    public class CreateUserApplicationCommandHandler : IRequestHandler<CreateUserApplicationCommand, CreatedUserApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserApplicationRepository _userApplicationRepository;
        private readonly UserApplicationBusinessRules _userApplicationBusinessRules;

        public CreateUserApplicationCommandHandler(IMapper mapper, IUserApplicationRepository userApplicationRepository,
                                         UserApplicationBusinessRules userApplicationBusinessRules)
        {
            _mapper = mapper;
            _userApplicationRepository = userApplicationRepository;
            _userApplicationBusinessRules = userApplicationBusinessRules;
        }

        public async Task<CreatedUserApplicationResponse> Handle(CreateUserApplicationCommand request, CancellationToken cancellationToken)
        {
            UserApplication userApplication = _mapper.Map<UserApplication>(request);

            await _userApplicationRepository.AddAsync(userApplication);

            CreatedUserApplicationResponse response = _mapper.Map<CreatedUserApplicationResponse>(userApplication);
            return response;
        }
    }
}