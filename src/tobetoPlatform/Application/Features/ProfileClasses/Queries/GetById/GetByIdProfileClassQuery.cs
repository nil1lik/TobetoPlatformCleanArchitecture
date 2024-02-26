using Application.Features.ProfileClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileClasses.Queries.GetById;

public class GetByIdProfileClassQuery : IRequest<GetByIdProfileClassResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileClassQueryHandler : IRequestHandler<GetByIdProfileClassQuery, GetByIdProfileClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileClassRepository _profileClassRepository;
        private readonly ProfileClassBusinessRules _profileClassBusinessRules;

        public GetByIdProfileClassQueryHandler(IMapper mapper, IProfileClassRepository profileClassRepository, ProfileClassBusinessRules profileClassBusinessRules)
        {
            _mapper = mapper;
            _profileClassRepository = profileClassRepository;
            _profileClassBusinessRules = profileClassBusinessRules;
        }

        public async Task<GetByIdProfileClassResponse> Handle(GetByIdProfileClassQuery request, CancellationToken cancellationToken)
        {
            ProfileClass? profileClass = await _profileClassRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _profileClassBusinessRules.ProfileClassShouldExistWhenSelected(profileClass);

            GetByIdProfileClassResponse response = _mapper.Map<GetByIdProfileClassResponse>(profileClass);
            return response;
        }
    }
}