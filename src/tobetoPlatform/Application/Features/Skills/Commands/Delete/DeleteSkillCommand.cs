using Application.Features.Skills.Constants;
using Application.Features.Skills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Skills.Commands.Delete;

public class DeleteSkillCommand : IRequest<DeletedSkillResponse>
{
    public int Id { get; set; }

    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, DeletedSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;
        private readonly SkillBusinessRules _skillBusinessRules;

        public DeleteSkillCommandHandler(IMapper mapper, ISkillRepository skillRepository,
                                         SkillBusinessRules skillBusinessRules)
        {
            _mapper = mapper;
            _skillRepository = skillRepository;
            _skillBusinessRules = skillBusinessRules;
        }

        public async Task<DeletedSkillResponse> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            Skill? skill = await _skillRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _skillBusinessRules.SkillShouldExistWhenSelected(skill);

            await _skillRepository.DeleteAsync(skill!);
            DeletedSkillResponse response = _mapper.Map<DeletedSkillResponse>(skill);
            response.Message = "Yetenek kaldýrýldý.";
            return response;
        }
    }
}