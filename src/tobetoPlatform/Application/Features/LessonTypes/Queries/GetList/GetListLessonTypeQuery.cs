using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.LessonTypes.Queries.GetList;

public class GetListLessonTypeQuery : IRequest<GetListResponse<GetListLessonTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLessonTypeQueryHandler : IRequestHandler<GetListLessonTypeQuery, GetListResponse<GetListLessonTypeListItemDto>>
    {
        private readonly ILessonTypeRepository _lessonTypeRepository;
        private readonly IMapper _mapper;

        public GetListLessonTypeQueryHandler(ILessonTypeRepository lessonTypeRepository, IMapper mapper)
        {
            _lessonTypeRepository = lessonTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLessonTypeListItemDto>> Handle(GetListLessonTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LessonType> lessonTypes = await _lessonTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLessonTypeListItemDto> response = _mapper.Map<GetListResponse<GetListLessonTypeListItemDto>>(lessonTypes);
            return response;
        }
    }
}