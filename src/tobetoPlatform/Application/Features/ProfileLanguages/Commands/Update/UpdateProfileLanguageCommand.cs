using Application.Features.ProfileLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileLanguages.Commands.Update;

public class UpdateProfileLanguageCommand : IRequest<UpdatedProfileLanguageResponse>
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int LanguageId { get; set; }

    public class UpdateProfileLanguageCommandHandler : IRequestHandler<UpdateProfileLanguageCommand, UpdatedProfileLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileLanguageRepository _profileLanguageRepository;
        private readonly ProfileLanguageBusinessRules _profileLanguageBusinessRules;

        public UpdateProfileLanguageCommandHandler(IMapper mapper, IProfileLanguageRepository profileLanguageRepository,
                                         ProfileLanguageBusinessRules profileLanguageBusinessRules)
        {
            _mapper = mapper;
            _profileLanguageRepository = profileLanguageRepository;
            _profileLanguageBusinessRules = profileLanguageBusinessRules;
        }

        public async Task<UpdatedProfileLanguageResponse> Handle(UpdateProfileLanguageCommand request, CancellationToken cancellationToken)
        {
            ProfileLanguage? profileLanguage = await _profileLanguageRepository.GetAsync(predicate: pl => pl.Id == request.Id, cancellationToken: cancellationToken);
            await _profileLanguageBusinessRules.ProfileLanguageShouldExistWhenSelected(profileLanguage);
            profileLanguage = _mapper.Map(request, profileLanguage);

            await _profileLanguageRepository.UpdateAsync(profileLanguage!);

            UpdatedProfileLanguageResponse response = _mapper.Map<UpdatedProfileLanguageResponse>(profileLanguage);
            return response;
        }
    }
}