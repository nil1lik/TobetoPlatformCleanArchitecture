using Application.Features.ProfileShares.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileShares.Commands.Create;

public class CreateProfileShareCommand : IRequest<CreatedProfileShareResponse>
{
    public Guid ProfileUrl { get; set; }
    public bool IsShare { get; set; }

    public class CreateProfileShareCommandHandler : IRequestHandler<CreateProfileShareCommand, CreatedProfileShareResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileShareRepository _profileShareRepository;
        private readonly ProfileShareBusinessRules _profileShareBusinessRules;

        public CreateProfileShareCommandHandler(IMapper mapper, IProfileShareRepository profileShareRepository,
                                         ProfileShareBusinessRules profileShareBusinessRules)
        {
            _mapper = mapper;
            _profileShareRepository = profileShareRepository;
            _profileShareBusinessRules = profileShareBusinessRules;
        }

        public async Task<CreatedProfileShareResponse> Handle(CreateProfileShareCommand request, CancellationToken cancellationToken)
        {
            ProfileShare profileShare = _mapper.Map<ProfileShare>(request);

            await _profileShareRepository.AddAsync(profileShare);

            CreatedProfileShareResponse response = _mapper.Map<CreatedProfileShareResponse>(profileShare);
            return response;
        }
    }
}