using Application.Features.Experiences.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Experiences.Queries.GetById;

public class GetByIdExperienceQuery : IRequest<GetByIdExperienceResponse>
{
    public int Id { get; set; }

    public class GetByIdExperienceQueryHandler : IRequestHandler<GetByIdExperienceQuery, GetByIdExperienceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExperienceRepository _experienceRepository;
        private readonly ExperienceBusinessRules _experienceBusinessRules;

        public GetByIdExperienceQueryHandler(IMapper mapper, IExperienceRepository experienceRepository, ExperienceBusinessRules experienceBusinessRules)
        {
            _mapper = mapper;
            _experienceRepository = experienceRepository;
            _experienceBusinessRules = experienceBusinessRules;
        }

        public async Task<GetByIdExperienceResponse> Handle(GetByIdExperienceQuery request, CancellationToken cancellationToken)
        {
            Experience? experience = await _experienceRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _experienceBusinessRules.ExperienceShouldExistWhenSelected(experience);

            GetByIdExperienceResponse response = _mapper.Map<GetByIdExperienceResponse>(experience);
            return response;
        }
    }
}