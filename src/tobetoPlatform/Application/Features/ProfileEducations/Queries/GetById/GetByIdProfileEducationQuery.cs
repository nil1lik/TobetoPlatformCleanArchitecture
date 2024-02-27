using Application.Features.ProfileEducations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileEducations.Queries.GetById;

public class GetByIdProfileEducationQuery : IRequest<GetByIdProfileEducationResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileEducationQueryHandler : IRequestHandler<GetByIdProfileEducationQuery, GetByIdProfileEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileEducationRepository _profileEducationRepository;
        private readonly ProfileEducationBusinessRules _profileEducationBusinessRules;

        public GetByIdProfileEducationQueryHandler(IMapper mapper, IProfileEducationRepository profileEducationRepository, ProfileEducationBusinessRules profileEducationBusinessRules)
        {
            _mapper = mapper;
            _profileEducationRepository = profileEducationRepository;
            _profileEducationBusinessRules = profileEducationBusinessRules;
        }

        public async Task<GetByIdProfileEducationResponse> Handle(GetByIdProfileEducationQuery request, CancellationToken cancellationToken)
        {
            ProfileEducation? profileEducation = await _profileEducationRepository.GetAsync(predicate: pe => pe.Id == request.Id, cancellationToken: cancellationToken);
            await _profileEducationBusinessRules.ProfileEducationShouldExistWhenSelected(profileEducation);

            GetByIdProfileEducationResponse response = _mapper.Map<GetByIdProfileEducationResponse>(profileEducation);
            return response;
        }
    }
}