using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.LessonVideoDetails.Queries.GetList;

public class GetListLessonVideoDetailQuery : IRequest<GetListResponse<GetListLessonVideoDetailListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLessonVideoDetailQueryHandler : IRequestHandler<GetListLessonVideoDetailQuery, GetListResponse<GetListLessonVideoDetailListItemDto>>
    {
        private readonly ILessonVideoDetailRepository _lessonVideoDetailRepository;
        private readonly IMapper _mapper;

        public GetListLessonVideoDetailQueryHandler(ILessonVideoDetailRepository lessonVideoDetailRepository, IMapper mapper)
        {
            _lessonVideoDetailRepository = lessonVideoDetailRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLessonVideoDetailListItemDto>> Handle(GetListLessonVideoDetailQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LessonVideoDetail> lessonVideoDetails = await _lessonVideoDetailRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLessonVideoDetailListItemDto> response = _mapper.Map<GetListResponse<GetListLessonVideoDetailListItemDto>>(lessonVideoDetails);
            return response;
        }
    }
}