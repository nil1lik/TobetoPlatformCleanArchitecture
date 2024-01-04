using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CourseClasses.Queries.GetList;

public class GetListCourseClassQuery : IRequest<GetListResponse<GetListCourseClassListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCourseClassQueryHandler : IRequestHandler<GetListCourseClassQuery, GetListResponse<GetListCourseClassListItemDto>>
    {
        private readonly ICourseClassRepository _courseClassRepository;
        private readonly IMapper _mapper;

        public GetListCourseClassQueryHandler(ICourseClassRepository courseClassRepository, IMapper mapper)
        {
            _courseClassRepository = courseClassRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCourseClassListItemDto>> Handle(GetListCourseClassQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseClass> courseClasses = await _courseClassRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCourseClassListItemDto> response = _mapper.Map<GetListResponse<GetListCourseClassListItemDto>>(courseClasses);
            return response;
        }
    }
}