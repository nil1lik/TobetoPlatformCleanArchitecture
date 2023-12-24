using Application.Features.ProfileApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileApplications.Queries.GetById;

public class GetByIdProfileApplicationQuery : IRequest<GetByIdProfileApplicationResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileApplicationQueryHandler : IRequestHandler<GetByIdProfileApplicationQuery, GetByIdProfileApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileApplicationRepository _profileApplicationRepository;
        private readonly ProfileApplicationBusinessRules _profileApplicationBusinessRules;

        public GetByIdProfileApplicationQueryHandler(IMapper mapper, IProfileApplicationRepository profileApplicationRepository, ProfileApplicationBusinessRules profileApplicationBusinessRules)
        {
            _mapper = mapper;
            _profileApplicationRepository = profileApplicationRepository;
            _profileApplicationBusinessRules = profileApplicationBusinessRules;
        }

        public async Task<GetByIdProfileApplicationResponse> Handle(GetByIdProfileApplicationQuery request, CancellationToken cancellationToken)
        {
            ProfileApplication? profileApplication = await _profileApplicationRepository.GetAsync(predicate: pa => pa.Id == request.Id, cancellationToken: cancellationToken);
            await _profileApplicationBusinessRules.ProfileApplicationShouldExistWhenSelected(profileApplication);

            GetByIdProfileApplicationResponse response = _mapper.Map<GetByIdProfileApplicationResponse>(profileApplication);
            return response;
        }
    }
}