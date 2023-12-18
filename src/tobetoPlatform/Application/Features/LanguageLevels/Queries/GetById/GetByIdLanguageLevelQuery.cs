using Application.Features.LanguageLevels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LanguageLevels.Queries.GetById;

public class GetByIdLanguageLevelQuery : IRequest<GetByIdLanguageLevelResponse>
{
    public int Id { get; set; }

    public class GetByIdLanguageLevelQueryHandler : IRequestHandler<GetByIdLanguageLevelQuery, GetByIdLanguageLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageLevelRepository _languageLevelRepository;
        private readonly LanguageLevelBusinessRules _languageLevelBusinessRules;

        public GetByIdLanguageLevelQueryHandler(IMapper mapper, ILanguageLevelRepository languageLevelRepository, LanguageLevelBusinessRules languageLevelBusinessRules)
        {
            _mapper = mapper;
            _languageLevelRepository = languageLevelRepository;
            _languageLevelBusinessRules = languageLevelBusinessRules;
        }

        public async Task<GetByIdLanguageLevelResponse> Handle(GetByIdLanguageLevelQuery request, CancellationToken cancellationToken)
        {
            LanguageLevel? languageLevel = await _languageLevelRepository.GetAsync(predicate: ll => ll.Id == request.Id, cancellationToken: cancellationToken);
            await _languageLevelBusinessRules.LanguageLevelShouldExistWhenSelected(languageLevel);

            GetByIdLanguageLevelResponse response = _mapper.Map<GetByIdLanguageLevelResponse>(languageLevel);
            return response;
        }
    }
}