using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.Create;

public class CreateLanguageCommand : IRequest<CreatedLanguageResponse>
{
    public string Name { get; set; }
    public int LanguageLevelId { get; set; }

    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public CreateLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository,
                                         LanguageBusinessRules languageBusinessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<CreatedLanguageResponse> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            Language language = _mapper.Map<Language>(request);
            await _languageBusinessRules.LanguageShouldNotBeTheSame(request.Name, language);
            await _languageRepository.AddAsync(language);
            CreatedLanguageResponse response = _mapper.Map<CreatedLanguageResponse>(language);
            response.Message = "Yabancý dil bilgisi eklendi";
            return response;
        }
    }
}