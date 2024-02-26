using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileLanguages.Queries.GetList;

public class GetListProfileLanguageQuery : IRequest<GetListResponse<GetListProfileLanguageListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileLanguageQueryHandler : IRequestHandler<GetListProfileLanguageQuery, GetListResponse<GetListProfileLanguageListItemDto>>
    {
        private readonly IProfileLanguageRepository _profileLanguageRepository;
        private readonly IMapper _mapper;

        public GetListProfileLanguageQueryHandler(IProfileLanguageRepository profileLanguageRepository, IMapper mapper)
        {
            _profileLanguageRepository = profileLanguageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileLanguageListItemDto>> Handle(GetListProfileLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileLanguage> profileLanguages = await _profileLanguageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileLanguageListItemDto> response = _mapper.Map<GetListResponse<GetListProfileLanguageListItemDto>>(profileLanguages);
            return response;
        }
    }
}