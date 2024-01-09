using Application.Features.VideoLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoLanguages.Commands.Update;

public class UpdateVideoLanguageCommand : IRequest<UpdatedVideoLanguageResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateVideoLanguageCommandHandler : IRequestHandler<UpdateVideoLanguageCommand, UpdatedVideoLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoLanguageRepository _videoLanguageRepository;
        private readonly VideoLanguageBusinessRules _videoLanguageBusinessRules;

        public UpdateVideoLanguageCommandHandler(IMapper mapper, IVideoLanguageRepository videoLanguageRepository,
                                         VideoLanguageBusinessRules videoLanguageBusinessRules)
        {
            _mapper = mapper;
            _videoLanguageRepository = videoLanguageRepository;
            _videoLanguageBusinessRules = videoLanguageBusinessRules;
        }

        public async Task<UpdatedVideoLanguageResponse> Handle(UpdateVideoLanguageCommand request, CancellationToken cancellationToken)
        {
            VideoLanguage? videoLanguage = await _videoLanguageRepository.GetAsync(predicate: vl => vl.Id == request.Id, cancellationToken: cancellationToken);
            await _videoLanguageBusinessRules.VideoLanguageShouldExistWhenSelected(videoLanguage);
            videoLanguage = _mapper.Map(request, videoLanguage);

            await _videoLanguageRepository.UpdateAsync(videoLanguage!);

            UpdatedVideoLanguageResponse response = _mapper.Map<UpdatedVideoLanguageResponse>(videoLanguage);
            return response;
        }
    }
}