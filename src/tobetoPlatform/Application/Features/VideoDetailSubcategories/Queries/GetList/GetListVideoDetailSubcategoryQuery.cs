using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.VideoDetailSubcategories.Queries.GetList;

public class GetListVideoDetailSubcategoryQuery : IRequest<GetListResponse<GetListVideoDetailSubcategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListVideoDetailSubcategoryQueryHandler : IRequestHandler<GetListVideoDetailSubcategoryQuery, GetListResponse<GetListVideoDetailSubcategoryListItemDto>>
    {
        private readonly IVideoDetailSubcategoryRepository _videoDetailSubcategoryRepository;
        private readonly IMapper _mapper;

        public GetListVideoDetailSubcategoryQueryHandler(IVideoDetailSubcategoryRepository videoDetailSubcategoryRepository, IMapper mapper)
        {
            _videoDetailSubcategoryRepository = videoDetailSubcategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListVideoDetailSubcategoryListItemDto>> Handle(GetListVideoDetailSubcategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<VideoDetailSubcategory> videoDetailSubcategories = await _videoDetailSubcategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListVideoDetailSubcategoryListItemDto> response = _mapper.Map<GetListResponse<GetListVideoDetailSubcategoryListItemDto>>(videoDetailSubcategories);
            return response;
        }
    }
}