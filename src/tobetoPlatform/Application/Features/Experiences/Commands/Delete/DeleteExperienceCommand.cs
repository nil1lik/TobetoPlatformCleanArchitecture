using Application.Features.Experiences.Constants;
using Application.Features.Experiences.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Experiences.Commands.Delete;

public class DeleteExperienceCommand : IRequest<DeletedExperienceResponse>
{
    public int Id { get; set; }

    public class DeleteExperienceCommandHandler : IRequestHandler<DeleteExperienceCommand, DeletedExperienceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExperienceRepository _experienceRepository;
        private readonly ExperienceBusinessRules _experienceBusinessRules;

        public DeleteExperienceCommandHandler(IMapper mapper, IExperienceRepository experienceRepository,
                                         ExperienceBusinessRules experienceBusinessRules)
        {
            _mapper = mapper;
            _experienceRepository = experienceRepository;
            _experienceBusinessRules = experienceBusinessRules;
        }

        public async Task<DeletedExperienceResponse> Handle(DeleteExperienceCommand request, CancellationToken cancellationToken)
        {
            Experience? experience = await _experienceRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _experienceBusinessRules.ExperienceShouldExistWhenSelected(experience);

            await _experienceRepository.DeleteAsync(experience!);

            DeletedExperienceResponse response = _mapper.Map<DeletedExperienceResponse>(experience);
            return response;
        }
    }
}