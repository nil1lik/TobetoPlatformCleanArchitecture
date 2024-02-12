using Application.Features.ProfileSkills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileSkills.Queries.GetById;

public class GetByIdProfileSkillQuery : IRequest<GetByIdProfileSkillResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileSkillQueryHandler : IRequestHandler<GetByIdProfileSkillQuery, GetByIdProfileSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileSkillRepository _profileSkillRepository;
        private readonly ProfileSkillBusinessRules _profileSkillBusinessRules;

        public GetByIdProfileSkillQueryHandler(IMapper mapper, IProfileSkillRepository profileSkillRepository, ProfileSkillBusinessRules profileSkillBusinessRules)
        {
            _mapper = mapper;
            _profileSkillRepository = profileSkillRepository;
            _profileSkillBusinessRules = profileSkillBusinessRules;
        }

        public async Task<GetByIdProfileSkillResponse> Handle(GetByIdProfileSkillQuery request, CancellationToken cancellationToken)
        {
            ProfileSkill? profileSkill = await _profileSkillRepository.GetAsync(predicate: ps => ps.Id == request.Id, cancellationToken: cancellationToken);
            await _profileSkillBusinessRules.ProfileSkillShouldExistWhenSelected(profileSkill);

            GetByIdProfileSkillResponse response = _mapper.Map<GetByIdProfileSkillResponse>(profileSkill);
            return response;
        }
    }
}