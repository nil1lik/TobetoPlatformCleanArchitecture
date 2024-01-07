using Application.Features.VideoLanguages.Constants;
using Application.Features.VideoLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoLanguages.Commands.Delete;

public class DeleteVideoLanguageCommand : IRequest<DeletedVideoLanguageResponse>
{
    public int Id { get; set; }

    public class DeleteVideoLanguageCommandHandler : IRequestHandler<DeleteVideoLanguageCommand, DeletedVideoLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoLanguageRepository _videoLanguageRepository;
        private readonly VideoLanguageBusinessRules _videoLanguageBusinessRules;

        public DeleteVideoLanguageCommandHandler(IMapper mapper, IVideoLanguageRepository videoLanguageRepository,
                                         VideoLanguageBusinessRules videoLanguageBusinessRules)
        {
            _mapper = mapper;
            _videoLanguageRepository = videoLanguageRepository;
            _videoLanguageBusinessRules = videoLanguageBusinessRules;
        }

        public async Task<DeletedVideoLanguageResponse> Handle(DeleteVideoLanguageCommand request, CancellationToken cancellationToken)
        {
            VideoLanguage? videoLanguage = await _videoLanguageRepository.GetAsync(predicate: vl => vl.Id == request.Id, cancellationToken: cancellationToken);
            await _videoLanguageBusinessRules.VideoLanguageShouldExistWhenSelected(videoLanguage);

            await _videoLanguageRepository.DeleteAsync(videoLanguage!);

            DeletedVideoLanguageResponse response = _mapper.Map<DeletedVideoLanguageResponse>(videoLanguage);
            return response;
        }
    }
}