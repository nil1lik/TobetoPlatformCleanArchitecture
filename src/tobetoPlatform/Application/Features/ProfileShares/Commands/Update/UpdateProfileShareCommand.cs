using Application.Features.ProfileShares.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileShares.Commands.Update;

public class UpdateProfileShareCommand : IRequest<UpdatedProfileShareResponse>
{
    public int Id { get; set; }
    public Guid ProfileUrl { get; set; }
    public bool IsShare { get; set; }

    public class UpdateProfileShareCommandHandler : IRequestHandler<UpdateProfileShareCommand, UpdatedProfileShareResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileShareRepository _profileShareRepository;
        private readonly ProfileShareBusinessRules _profileShareBusinessRules;

        public UpdateProfileShareCommandHandler(IMapper mapper, IProfileShareRepository profileShareRepository,
                                         ProfileShareBusinessRules profileShareBusinessRules)
        {
            _mapper = mapper;
            _profileShareRepository = profileShareRepository;
            _profileShareBusinessRules = profileShareBusinessRules;
        }

        public async Task<UpdatedProfileShareResponse> Handle(UpdateProfileShareCommand request, CancellationToken cancellationToken)
        {
            ProfileShare? profileShare = await _profileShareRepository.GetAsync(predicate: ps => ps.Id == request.Id, cancellationToken: cancellationToken);
            await _profileShareBusinessRules.ProfileShareShouldExistWhenSelected(profileShare);
            profileShare = _mapper.Map(request, profileShare);

            await _profileShareRepository.UpdateAsync(profileShare!);

            UpdatedProfileShareResponse response = _mapper.Map<UpdatedProfileShareResponse>(profileShare);
            return response;
        }
    }
}