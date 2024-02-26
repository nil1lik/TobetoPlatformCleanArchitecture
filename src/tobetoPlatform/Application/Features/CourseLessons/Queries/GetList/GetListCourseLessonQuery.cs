using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CourseLessons.Queries.GetList;

public class GetListCourseLessonQuery : IRequest<GetListResponse<GetListCourseLessonListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCourseLessonQueryHandler : IRequestHandler<GetListCourseLessonQuery, GetListResponse<GetListCourseLessonListItemDto>>
    {
        private readonly ICourseLessonRepository _courseLessonRepository;
        private readonly IMapper _mapper;

        public GetListCourseLessonQueryHandler(ICourseLessonRepository courseLessonRepository, IMapper mapper)
        {
            _courseLessonRepository = courseLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCourseLessonListItemDto>> Handle(GetListCourseLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseLesson> courseLessons = await _courseLessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCourseLessonListItemDto> response = _mapper.Map<GetListResponse<GetListCourseLessonListItemDto>>(courseLessons);
            return response;
        }
    }
}