using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.Features.Courses.Queries.GetSyncLessonsByCourseId
{
    public class GetSyncLessonsByCourseIdQuery : IRequest<GetSyncLessonsByCourseIdResponse>
    {
        public int Id { get; set; }

        public class GetSyncLessonsByCourseIdQueryHandler : IRequestHandler<GetSyncLessonsByCourseIdQuery, GetSyncLessonsByCourseIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly ICourseRepository _courseRepository;
            private readonly CourseBusinessRules _courseBusinessRules;

            public GetSyncLessonsByCourseIdQueryHandler(IMapper mapper, ICourseRepository courseRepository, CourseBusinessRules courseBusinessRules)
            {
                _mapper = mapper;
                _courseRepository = courseRepository;
                _courseBusinessRules = courseBusinessRules;
            }

            public async Task<GetSyncLessonsByCourseIdResponse> Handle(GetSyncLessonsByCourseIdQuery request, CancellationToken cancellationToken)
            {
                Course? course = await _courseRepository.GetAsync(predicate: sl => sl.Id == request.Id,
                    include: sl => sl.Include(sl => sl.SyncLessons),
                    cancellationToken: cancellationToken);
                await _courseBusinessRules.CourseShouldExistWhenSelected(course);

                GetSyncLessonsByCourseIdResponse response = _mapper.Map<GetSyncLessonsByCourseIdResponse>(course);
                return response;

            }
        }
    }
}
