using Application.Features.Languages.Constants;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.Delete;

public class DeleteLanguageCommand : IRequest<DeletedLanguageResponse>
{
    public int Id { get; set; }

    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public DeleteLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository,
                                         LanguageBusinessRules languageBusinessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<DeletedLanguageResponse> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _languageBusinessRules.LanguageShouldExistWhenSelected(language);

            await _languageRepository.DeleteAsync(language!);

            DeletedLanguageResponse response = _mapper.Map<DeletedLanguageResponse>(language);
            return response;
        }
    }
}