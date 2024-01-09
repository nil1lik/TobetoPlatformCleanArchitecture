using Application.Features.VideoLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoLanguages.Queries.GetById;

public class GetByIdVideoLanguageQuery : IRequest<GetByIdVideoLanguageResponse>
{
    public int Id { get; set; }

    public class GetByIdVideoLanguageQueryHandler : IRequestHandler<GetByIdVideoLanguageQuery, GetByIdVideoLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoLanguageRepository _videoLanguageRepository;
        private readonly VideoLanguageBusinessRules _videoLanguageBusinessRules;

        public GetByIdVideoLanguageQueryHandler(IMapper mapper, IVideoLanguageRepository videoLanguageRepository, VideoLanguageBusinessRules videoLanguageBusinessRules)
        {
            _mapper = mapper;
            _videoLanguageRepository = videoLanguageRepository;
            _videoLanguageBusinessRules = videoLanguageBusinessRules;
        }

        public async Task<GetByIdVideoLanguageResponse> Handle(GetByIdVideoLanguageQuery request, CancellationToken cancellationToken)
        {
            VideoLanguage? videoLanguage = await _videoLanguageRepository.GetAsync(predicate: vl => vl.Id == request.Id, cancellationToken: cancellationToken);
            await _videoLanguageBusinessRules.VideoLanguageShouldExistWhenSelected(videoLanguage);

            GetByIdVideoLanguageResponse response = _mapper.Map<GetByIdVideoLanguageResponse>(videoLanguage);
            return response;
        }
    }
}