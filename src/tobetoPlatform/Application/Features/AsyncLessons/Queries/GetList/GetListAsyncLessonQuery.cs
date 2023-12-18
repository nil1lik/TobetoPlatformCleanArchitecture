using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.AsyncLessons.Queries.GetList;

public class GetListAsyncLessonQuery : IRequest<GetListResponse<GetListAsyncLessonListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAsyncLessonQueryHandler : IRequestHandler<GetListAsyncLessonQuery, GetListResponse<GetListAsyncLessonListItemDto>>
    {
        private readonly IAsyncLessonRepository _asyncLessonRepository;
        private readonly IMapper _mapper;

        public GetListAsyncLessonQueryHandler(IAsyncLessonRepository asyncLessonRepository, IMapper mapper)
        {
            _asyncLessonRepository = asyncLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAsyncLessonListItemDto>> Handle(GetListAsyncLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AsyncLesson> asyncLessons = await _asyncLessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAsyncLessonListItemDto> response = _mapper.Map<GetListResponse<GetListAsyncLessonListItemDto>>(asyncLessons);
            return response;
        }
    }
}