using Application.Features.ProfileGraduations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileGraduations.Queries.GetById;

public class GetByIdProfileGraduationQuery : IRequest<GetByIdProfileGraduationResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileGraduationQueryHandler : IRequestHandler<GetByIdProfileGraduationQuery, GetByIdProfileGraduationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileGraduationRepository _profileGraduationRepository;
        private readonly ProfileGraduationBusinessRules _profileGraduationBusinessRules;

        public GetByIdProfileGraduationQueryHandler(IMapper mapper, IProfileGraduationRepository profileGraduationRepository, ProfileGraduationBusinessRules profileGraduationBusinessRules)
        {
            _mapper = mapper;
            _profileGraduationRepository = profileGraduationRepository;
            _profileGraduationBusinessRules = profileGraduationBusinessRules;
        }

        public async Task<GetByIdProfileGraduationResponse> Handle(GetByIdProfileGraduationQuery request, CancellationToken cancellationToken)
        {
            ProfileGraduation? profileGraduation = await _profileGraduationRepository.GetAsync(predicate: pg => pg.Id == request.Id, cancellationToken: cancellationToken);
            await _profileGraduationBusinessRules.ProfileGraduationShouldExistWhenSelected(profileGraduation);

            GetByIdProfileGraduationResponse response = _mapper.Map<GetByIdProfileGraduationResponse>(profileGraduation);
            return response;
        }
    }
}