using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Languages.Queries.GetList;

public class GetListLanguageQuery : IRequest<GetListResponse<GetListLanguageListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, GetListResponse<GetListLanguageListItemDto>>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLanguageListItemDto>> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Language> languages = await _languageRepository.GetListAsync(
                include: l => l.Include(x => x.LanguageLevel),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLanguageListItemDto> response = _mapper.Map<GetListResponse<GetListLanguageListItemDto>>(languages);
            return response;
        }
    }
}