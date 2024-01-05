using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SyncLessons.Queries.GetList;

public class GetListSyncLessonQuery : IRequest<GetListResponse<GetListSyncLessonListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSyncLessonQueryHandler : IRequestHandler<GetListSyncLessonQuery, GetListResponse<GetListSyncLessonListItemDto>>
    {
        private readonly ISyncLessonRepository _syncLessonRepository;
        private readonly IMapper _mapper;

        public GetListSyncLessonQueryHandler(ISyncLessonRepository syncLessonRepository, IMapper mapper)
        {
            _syncLessonRepository = syncLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSyncLessonListItemDto>> Handle(GetListSyncLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SyncLesson> syncLessons = await _syncLessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSyncLessonListItemDto> response = _mapper.Map<GetListResponse<GetListSyncLessonListItemDto>>(syncLessons);
            return response;
        }
    }
}