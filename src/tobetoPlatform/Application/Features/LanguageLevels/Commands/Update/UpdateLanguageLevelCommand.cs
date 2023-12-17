using Application.Features.LanguageLevels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LanguageLevels.Commands.Update;

public class UpdateLanguageLevelCommand : IRequest<UpdatedLanguageLevelResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateLanguageLevelCommandHandler : IRequestHandler<UpdateLanguageLevelCommand, UpdatedLanguageLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageLevelRepository _languageLevelRepository;
        private readonly LanguageLevelBusinessRules _languageLevelBusinessRules;

        public UpdateLanguageLevelCommandHandler(IMapper mapper, ILanguageLevelRepository languageLevelRepository,
                                         LanguageLevelBusinessRules languageLevelBusinessRules)
        {
            _mapper = mapper;
            _languageLevelRepository = languageLevelRepository;
            _languageLevelBusinessRules = languageLevelBusinessRules;
        }

        public async Task<UpdatedLanguageLevelResponse> Handle(UpdateLanguageLevelCommand request, CancellationToken cancellationToken)
        {
            LanguageLevel? languageLevel = await _languageLevelRepository.GetAsync(predicate: ll => ll.Id == request.Id, cancellationToken: cancellationToken);
            await _languageLevelBusinessRules.LanguageLevelShouldExistWhenSelected(languageLevel);
            languageLevel = _mapper.Map(request, languageLevel);

            await _languageLevelRepository.UpdateAsync(languageLevel!);

            UpdatedLanguageLevelResponse response = _mapper.Map<UpdatedLanguageLevelResponse>(languageLevel);
            return response;
        }
    }
}