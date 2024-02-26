using Application.Features.ProfileLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileLanguages.Queries.GetById;

public class GetByIdProfileLanguageQuery : IRequest<GetByIdProfileLanguageResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileLanguageQueryHandler : IRequestHandler<GetByIdProfileLanguageQuery, GetByIdProfileLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileLanguageRepository _profileLanguageRepository;
        private readonly ProfileLanguageBusinessRules _profileLanguageBusinessRules;

        public GetByIdProfileLanguageQueryHandler(IMapper mapper, IProfileLanguageRepository profileLanguageRepository, ProfileLanguageBusinessRules profileLanguageBusinessRules)
        {
            _mapper = mapper;
            _profileLanguageRepository = profileLanguageRepository;
            _profileLanguageBusinessRules = profileLanguageBusinessRules;
        }

        public async Task<GetByIdProfileLanguageResponse> Handle(GetByIdProfileLanguageQuery request, CancellationToken cancellationToken)
        {
            ProfileLanguage? profileLanguage = await _profileLanguageRepository.GetAsync(predicate: pl => pl.Id == request.Id, cancellationToken: cancellationToken);
            await _profileLanguageBusinessRules.ProfileLanguageShouldExistWhenSelected(profileLanguage);

            GetByIdProfileLanguageResponse response = _mapper.Map<GetByIdProfileLanguageResponse>(profileLanguage);
            return response;
        }
    }
}