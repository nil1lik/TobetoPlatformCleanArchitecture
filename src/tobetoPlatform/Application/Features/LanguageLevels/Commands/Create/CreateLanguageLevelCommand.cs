using Application.Features.LanguageLevels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LanguageLevels.Commands.Create;

public class CreateLanguageLevelCommand : IRequest<CreatedLanguageLevelResponse>
{
    public string Name { get; set; }

    public class CreateLanguageLevelCommandHandler : IRequestHandler<CreateLanguageLevelCommand, CreatedLanguageLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageLevelRepository _languageLevelRepository;
        private readonly LanguageLevelBusinessRules _languageLevelBusinessRules;

        public CreateLanguageLevelCommandHandler(IMapper mapper, ILanguageLevelRepository languageLevelRepository,
                                         LanguageLevelBusinessRules languageLevelBusinessRules)
        {
            _mapper = mapper;
            _languageLevelRepository = languageLevelRepository;
            _languageLevelBusinessRules = languageLevelBusinessRules;
        }

        public async Task<CreatedLanguageLevelResponse> Handle(CreateLanguageLevelCommand request, CancellationToken cancellationToken)
        {
            LanguageLevel languageLevel = _mapper.Map<LanguageLevel>(request);

            await _languageLevelRepository.AddAsync(languageLevel);

            CreatedLanguageLevelResponse response = _mapper.Map<CreatedLanguageLevelResponse>(languageLevel);
            return response;
        }
    }
}