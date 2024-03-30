using Application.Features.ProfileAdmirations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileAdmirations.Queries.GetById;

public class GetByIdProfileAdmirationQuery : IRequest<GetByIdProfileAdmirationResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileAdmirationQueryHandler : IRequestHandler<GetByIdProfileAdmirationQuery, GetByIdProfileAdmirationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileAdmirationRepository _profileAdmirationRepository;
        private readonly ProfileAdmirationBusinessRules _profileAdmirationBusinessRules;

        public GetByIdProfileAdmirationQueryHandler(IMapper mapper, IProfileAdmirationRepository profileAdmirationRepository, ProfileAdmirationBusinessRules profileAdmirationBusinessRules)
        {
            _mapper = mapper;
            _profileAdmirationRepository = profileAdmirationRepository;
            _profileAdmirationBusinessRules = profileAdmirationBusinessRules;
        }

        public async Task<GetByIdProfileAdmirationResponse> Handle(GetByIdProfileAdmirationQuery request, CancellationToken cancellationToken)
        {
            ProfileAdmiration? profileAdmiration = await _profileAdmirationRepository.GetAsync(predicate: pa => pa.Id == request.Id, cancellationToken: cancellationToken);
            await _profileAdmirationBusinessRules.ProfileAdmirationShouldExistWhenSelected(profileAdmiration);

            GetByIdProfileAdmirationResponse response = _mapper.Map<GetByIdProfileAdmirationResponse>(profileAdmiration);
            return response;
        }
    }
}