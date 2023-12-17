using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.LanguageLevels.Queries.GetList;

public class GetListLanguageLevelQuery : IRequest<GetListResponse<GetListLanguageLevelListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLanguageLevelQueryHandler : IRequestHandler<GetListLanguageLevelQuery, GetListResponse<GetListLanguageLevelListItemDto>>
    {
        private readonly ILanguageLevelRepository _languageLevelRepository;
        private readonly IMapper _mapper;

        public GetListLanguageLevelQueryHandler(ILanguageLevelRepository languageLevelRepository, IMapper mapper)
        {
            _languageLevelRepository = languageLevelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLanguageLevelListItemDto>> Handle(GetListLanguageLevelQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LanguageLevel> languageLevels = await _languageLevelRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLanguageLevelListItemDto> response = _mapper.Map<GetListResponse<GetListLanguageLevelListItemDto>>(languageLevels);
            return response;
        }
    }
}