using Amazon.Runtime.Internal;
using Application.Features.AsyncLessons.Rules;
using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.Courses.Queries.GetAsyncLessonsByCourseId
{
    public class GetAsyncLessonsByCourseIdQuery : IRequest<GetAsyncLessonsByCourseIdResponse>
    {
        public int Id { get; set; } 

        public class GetAsyncLessonsByCourseIdQueryHandler : IRequestHandler<GetAsyncLessonsByCourseIdQuery, GetAsyncLessonsByCourseIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly ICourseRepository _courseRepository;
            private readonly CourseBusinessRules _courseBusinessRules;

            public GetAsyncLessonsByCourseIdQueryHandler(IMapper mapper, ICourseRepository courseRepository, CourseBusinessRules courseBusinessRules)
            {
                _mapper = mapper;
                _courseRepository = courseRepository;
                _courseBusinessRules = courseBusinessRules;
            }

            public async Task<GetAsyncLessonsByCourseIdResponse> Handle(GetAsyncLessonsByCourseIdQuery request, CancellationToken cancellationToken)
            {
                Course? course = await _courseRepository.GetAsync(predicate: c => c.Id == request.Id,
                    include: c => c.Include(c => c.CourseLesson).ThenInclude(al => al.AsyncLesson),
                    cancellationToken: cancellationToken);
                await _courseBusinessRules.CourseShouldExistWhenSelected(course);

                GetAsyncLessonsByCourseIdResponse response = _mapper.Map<GetAsyncLessonsByCourseIdResponse>(course);
                return response;
            }
        }
    }
}

