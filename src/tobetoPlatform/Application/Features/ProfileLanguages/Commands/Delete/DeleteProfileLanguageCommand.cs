using Application.Features.ProfileLanguages.Constants;
using Application.Features.ProfileLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileLanguages.Commands.Delete;

public class DeleteProfileLanguageCommand : IRequest<DeletedProfileLanguageResponse>
{
    public int Id { get; set; }

    public class DeleteProfileLanguageCommandHandler : IRequestHandler<DeleteProfileLanguageCommand, DeletedProfileLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileLanguageRepository _profileLanguageRepository;
        private readonly ProfileLanguageBusinessRules _profileLanguageBusinessRules;

        public DeleteProfileLanguageCommandHandler(IMapper mapper, IProfileLanguageRepository profileLanguageRepository,
                                         ProfileLanguageBusinessRules profileLanguageBusinessRules)
        {
            _mapper = mapper;
            _profileLanguageRepository = profileLanguageRepository;
            _profileLanguageBusinessRules = profileLanguageBusinessRules;
        }

        public async Task<DeletedProfileLanguageResponse> Handle(DeleteProfileLanguageCommand request, CancellationToken cancellationToken)
        {
            ProfileLanguage? profileLanguage = await _profileLanguageRepository.GetAsync(predicate: pl => pl.Id == request.Id, cancellationToken: cancellationToken);
            await _profileLanguageBusinessRules.ProfileLanguageShouldExistWhenSelected(profileLanguage);

            await _profileLanguageRepository.DeleteAsync(profileLanguage!);

            DeletedProfileLanguageResponse response = _mapper.Map<DeletedProfileLanguageResponse>(profileLanguage);
            return response;
        }
    }
}