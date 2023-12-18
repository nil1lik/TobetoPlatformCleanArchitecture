using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CourseInstructors.Queries.GetList;

public class GetListCourseInstructorQuery : IRequest<GetListResponse<GetListCourseInstructorListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCourseInstructorQueryHandler : IRequestHandler<GetListCourseInstructorQuery, GetListResponse<GetListCourseInstructorListItemDto>>
    {
        private readonly ICourseInstructorRepository _courseInstructorRepository;
        private readonly IMapper _mapper;

        public GetListCourseInstructorQueryHandler(ICourseInstructorRepository courseInstructorRepository, IMapper mapper)
        {
            _courseInstructorRepository = courseInstructorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCourseInstructorListItemDto>> Handle(GetListCourseInstructorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseInstructor> courseInstructors = await _courseInstructorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCourseInstructorListItemDto> response = _mapper.Map<GetListResponse<GetListCourseInstructorListItemDto>>(courseInstructors);
            return response;
        }
    }
}