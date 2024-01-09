using Application.Features.Experiences.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Experiences.Commands.Create;

public class CreateExperienceCommand : IRequest<CreatedExperienceResponse>
{
    public int UserProfileId { get; set; }
    public int CityId { get; set; }
    public string OrganizationName { get; set; }
    public string Position { get; set; }
    public string Sector { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }

    public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, CreatedExperienceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExperienceRepository _experienceRepository;
        private readonly ExperienceBusinessRules _experienceBusinessRules;

        public CreateExperienceCommandHandler(IMapper mapper, IExperienceRepository experienceRepository,
                                         ExperienceBusinessRules experienceBusinessRules)
        {
            _mapper = mapper;
            _experienceRepository = experienceRepository;
            _experienceBusinessRules = experienceBusinessRules;
        }

        public async Task<CreatedExperienceResponse> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
        {
            Experience experience = _mapper.Map<Experience>(request);

            await _experienceRepository.AddAsync(experience);

            CreatedExperienceResponse response = _mapper.Map<CreatedExperienceResponse>(experience);
            response.Message = "Deneyim eklendi";
            return response;
        }
    }
}