using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.VideoDetailCategories.Queries.GetList;

public class GetListVideoDetailCategoryQuery : IRequest<GetListResponse<GetListVideoDetailCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListVideoDetailCategoryQueryHandler : IRequestHandler<GetListVideoDetailCategoryQuery, GetListResponse<GetListVideoDetailCategoryListItemDto>>
    {
        private readonly IVideoDetailCategoryRepository _videoDetailCategoryRepository;
        private readonly IMapper _mapper;

        public GetListVideoDetailCategoryQueryHandler(IVideoDetailCategoryRepository videoDetailCategoryRepository, IMapper mapper)
        {
            _videoDetailCategoryRepository = videoDetailCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListVideoDetailCategoryListItemDto>> Handle(GetListVideoDetailCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<VideoDetailCategory> videoDetailCategories = await _videoDetailCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListVideoDetailCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListVideoDetailCategoryListItemDto>>(videoDetailCategories);
            return response;
        }
    }
}