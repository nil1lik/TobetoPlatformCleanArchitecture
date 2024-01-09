using Application.Features.Skills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Skills.Commands.Create;

public class CreateSkillCommand : IRequest<CreatedSkillResponse>
{
    public string Name { get; set; }

    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, CreatedSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;
        private readonly SkillBusinessRules _skillBusinessRules;

        public CreateSkillCommandHandler(IMapper mapper, ISkillRepository skillRepository,
                                         SkillBusinessRules skillBusinessRules)
        {
            _mapper = mapper;
            _skillRepository = skillRepository;
            _skillBusinessRules = skillBusinessRules;
        }

        public async Task<CreatedSkillResponse> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            Skill skill = _mapper.Map<Skill>(request);
            await _skillRepository.AddAsync(skill);
            CreatedSkillResponse response = _mapper.Map<CreatedSkillResponse>(skill);

            if (response.Id==skill.Id)
            {
                response.Message = "Yetenek eklendi";
            }
            return response;
        }
    }
}