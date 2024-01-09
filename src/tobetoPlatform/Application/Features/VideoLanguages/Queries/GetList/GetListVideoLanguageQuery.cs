using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.VideoLanguages.Queries.GetList;

public class GetListVideoLanguageQuery : IRequest<GetListResponse<GetListVideoLanguageListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListVideoLanguageQueryHandler : IRequestHandler<GetListVideoLanguageQuery, GetListResponse<GetListVideoLanguageListItemDto>>
    {
        private readonly IVideoLanguageRepository _videoLanguageRepository;
        private readonly IMapper _mapper;

        public GetListVideoLanguageQueryHandler(IVideoLanguageRepository videoLanguageRepository, IMapper mapper)
        {
            _videoLanguageRepository = videoLanguageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListVideoLanguageListItemDto>> Handle(GetListVideoLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<VideoLanguage> videoLanguages = await _videoLanguageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListVideoLanguageListItemDto> response = _mapper.Map<GetListResponse<GetListVideoLanguageListItemDto>>(videoLanguages);
            return response;
        }
    }
}