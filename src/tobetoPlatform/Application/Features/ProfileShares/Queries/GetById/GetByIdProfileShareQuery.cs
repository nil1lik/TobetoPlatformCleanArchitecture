using Application.Features.ProfileShares.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileShares.Queries.GetById;

public class GetByIdProfileShareQuery : IRequest<GetByIdProfileShareResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileShareQueryHandler : IRequestHandler<GetByIdProfileShareQuery, GetByIdProfileShareResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileShareRepository _profileShareRepository;
        private readonly ProfileShareBusinessRules _profileShareBusinessRules;

        public GetByIdProfileShareQueryHandler(IMapper mapper, IProfileShareRepository profileShareRepository, ProfileShareBusinessRules profileShareBusinessRules)
        {
            _mapper = mapper;
            _profileShareRepository = profileShareRepository;
            _profileShareBusinessRules = profileShareBusinessRules;
        }

        public async Task<GetByIdProfileShareResponse> Handle(GetByIdProfileShareQuery request, CancellationToken cancellationToken)
        {
            ProfileShare? profileShare = await _profileShareRepository.GetAsync(predicate: ps => ps.Id == request.Id, cancellationToken: cancellationToken);
            await _profileShareBusinessRules.ProfileShareShouldExistWhenSelected(profileShare);

            GetByIdProfileShareResponse response = _mapper.Map<GetByIdProfileShareResponse>(profileShare);
            return response;
        }
    }
}