using Application.Features.Skills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Skills.Commands.Update;

public class UpdateSkillCommand : IRequest<UpdatedSkillResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, UpdatedSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;
        private readonly SkillBusinessRules _skillBusinessRules;

        public UpdateSkillCommandHandler(IMapper mapper, ISkillRepository skillRepository,
                                         SkillBusinessRules skillBusinessRules)
        {
            _mapper = mapper;
            _skillRepository = skillRepository;
            _skillBusinessRules = skillBusinessRules;
        }

        public async Task<UpdatedSkillResponse> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            Skill? skill = await _skillRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _skillBusinessRules.SkillShouldExistWhenSelected(skill);
            skill = _mapper.Map(request, skill);

            await _skillRepository.UpdateAsync(skill!);

            UpdatedSkillResponse response = _mapper.Map<UpdatedSkillResponse>(skill);
            return response;
        }
    }
}