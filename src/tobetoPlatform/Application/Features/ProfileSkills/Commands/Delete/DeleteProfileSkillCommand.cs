using Application.Features.ProfileSkills.Constants;
using Application.Features.ProfileSkills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileSkills.Commands.Delete;

public class DeleteProfileSkillCommand : IRequest<DeletedProfileSkillResponse>
{
    public int Id { get; set; }

    public class DeleteProfileSkillCommandHandler : IRequestHandler<DeleteProfileSkillCommand, DeletedProfileSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileSkillRepository _profileSkillRepository;
        private readonly ProfileSkillBusinessRules _profileSkillBusinessRules;

        public DeleteProfileSkillCommandHandler(IMapper mapper, IProfileSkillRepository profileSkillRepository,
                                         ProfileSkillBusinessRules profileSkillBusinessRules)
        {
            _mapper = mapper;
            _profileSkillRepository = profileSkillRepository;
            _profileSkillBusinessRules = profileSkillBusinessRules;
        }

        public async Task<DeletedProfileSkillResponse> Handle(DeleteProfileSkillCommand request, CancellationToken cancellationToken)
        {
            ProfileSkill? profileSkill = await _profileSkillRepository.GetAsync(predicate: ps => ps.Id == request.Id, cancellationToken: cancellationToken);
            await _profileSkillBusinessRules.ProfileSkillShouldExistWhenSelected(profileSkill);

            await _profileSkillRepository.DeleteAsync(profileSkill!);

            DeletedProfileSkillResponse response = _mapper.Map<DeletedProfileSkillResponse>(profileSkill);
            return response;
        }
    }
}