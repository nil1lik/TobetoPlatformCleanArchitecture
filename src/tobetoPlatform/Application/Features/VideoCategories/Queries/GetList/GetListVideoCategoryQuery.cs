using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.VideoCategories.Queries.GetList;

public class GetListVideoCategoryQuery : IRequest<GetListResponse<GetListVideoCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListVideoCategoryQueryHandler : IRequestHandler<GetListVideoCategoryQuery, GetListResponse<GetListVideoCategoryListItemDto>>
    {
        private readonly IVideoCategoryRepository _videoCategoryRepository;
        private readonly IMapper _mapper;

        public GetListVideoCategoryQueryHandler(IVideoCategoryRepository videoCategoryRepository, IMapper mapper)
        {
            _videoCategoryRepository = videoCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListVideoCategoryListItemDto>> Handle(GetListVideoCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<VideoCategory> videoCategories = await _videoCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListVideoCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListVideoCategoryListItemDto>>(videoCategories);
            return response;
        }
    }
}