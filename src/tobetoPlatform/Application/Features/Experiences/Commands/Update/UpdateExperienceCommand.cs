using Application.Features.Experiences.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Experiences.Commands.Update;

public class UpdateExperienceCommand : IRequest<UpdatedExperienceResponse>
{
    public int Id { get; set; }
    public int CityId { get; set; }
    public string OrganizationName { get; set; }
    public string Position { get; set; }
    public string Sector { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }

    public class UpdateExperienceCommandHandler : IRequestHandler<UpdateExperienceCommand, UpdatedExperienceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExperienceRepository _experienceRepository;
        private readonly ExperienceBusinessRules _experienceBusinessRules;

        public UpdateExperienceCommandHandler(IMapper mapper, IExperienceRepository experienceRepository,
                                         ExperienceBusinessRules experienceBusinessRules)
        {
            _mapper = mapper;
            _experienceRepository = experienceRepository;
            _experienceBusinessRules = experienceBusinessRules;
        }

        public async Task<UpdatedExperienceResponse> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
        {
            Experience? experience = await _experienceRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _experienceBusinessRules.ExperienceShouldExistWhenSelected(experience);
            experience = _mapper.Map(request, experience);

            await _experienceRepository.UpdateAsync(experience!);

            UpdatedExperienceResponse response = _mapper.Map<UpdatedExperienceResponse>(experience);
            return response;
        }
    }
}