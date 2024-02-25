using Amazon.Runtime.Internal;
using Application.Features.ProfileSkills.Commands.Delete;
using Application.Features.ProfileSkills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProfileSkills.Commands.Delete.DeleteSkillByUserId;
public class DeleteSkillbyUserIdCommand : IRequest<DeleteSkillByUserIdResponse>
{
    public int UserProfileId { get; set; }
    public int SkillId { get; set; }

    public class DeleteSkillbyUserIdCommandHandler : IRequestHandler<DeleteSkillbyUserIdCommand, DeleteSkillByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileSkillRepository _profileSkillRepository;
        private readonly ProfileSkillBusinessRules _profileSkillBusinessRules;

        public DeleteSkillbyUserIdCommandHandler(IMapper mapper, IProfileSkillRepository profileSkillRepository,
                                         ProfileSkillBusinessRules profileSkillBusinessRules)
        {
            _mapper = mapper;
            _profileSkillRepository = profileSkillRepository;
            _profileSkillBusinessRules = profileSkillBusinessRules;
        }

        public async Task<DeleteSkillByUserIdResponse> Handle(DeleteSkillbyUserIdCommand request, CancellationToken cancellationToken)
        {
            ProfileSkill? profileSkill = await _profileSkillRepository.GetAsync(
                predicate: ps => ps.UserProfileId == request.UserProfileId
                        && ps.SkillId == request.SkillId,
                cancellationToken: cancellationToken);
            await _profileSkillBusinessRules.ProfileSkillShouldExistWhenSelected(profileSkill);

            await _profileSkillRepository.DeleteAsync(profileSkill!);

            DeleteSkillByUserIdResponse response = _mapper.Map<DeleteSkillByUserIdResponse>(profileSkill);
            return response;
        }
    }
}
