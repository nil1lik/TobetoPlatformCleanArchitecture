using Application.Features.VideoLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoLanguages.Commands.Create;

public class CreateVideoLanguageCommand : IRequest<CreatedVideoLanguageResponse>
{
    public string Name { get; set; }

    public class CreateVideoLanguageCommandHandler : IRequestHandler<CreateVideoLanguageCommand, CreatedVideoLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoLanguageRepository _videoLanguageRepository;
        private readonly VideoLanguageBusinessRules _videoLanguageBusinessRules;

        public CreateVideoLanguageCommandHandler(IMapper mapper, IVideoLanguageRepository videoLanguageRepository,
                                         VideoLanguageBusinessRules videoLanguageBusinessRules)
        {
            _mapper = mapper;
            _videoLanguageRepository = videoLanguageRepository;
            _videoLanguageBusinessRules = videoLanguageBusinessRules;
        }

        public async Task<CreatedVideoLanguageResponse> Handle(CreateVideoLanguageCommand request, CancellationToken cancellationToken)
        {
            VideoLanguage videoLanguage = _mapper.Map<VideoLanguage>(request);

            await _videoLanguageRepository.AddAsync(videoLanguage);

            CreatedVideoLanguageResponse response = _mapper.Map<CreatedVideoLanguageResponse>(videoLanguage);
            return response;
        }
    }
}