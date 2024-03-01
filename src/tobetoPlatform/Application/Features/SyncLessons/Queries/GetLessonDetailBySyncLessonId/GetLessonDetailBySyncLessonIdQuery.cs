using Application.Features.Courses.Queries.GetSyncLessonsByCourseId;
using Application.Features.Courses.Rules;
using Application.Features.SyncLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

namespace Application.Features.SyncLessons.Queries.GetLessonDetailBySyncLessonId
{
    public class GetLessonDetailBySyncLessonIdQuery : IRequest<GetLessonDetailBySyncLessonIdResponse>
    {
        public int Id { get; set; }

        public class GetLessonDetailBySyncLessonIdQueryHandler : IRequestHandler<GetLessonDetailBySyncLessonIdQuery, GetLessonDetailBySyncLessonIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly ISyncLessonRepository _syncLessonRepository;
            private readonly SyncLessonBusinessRules _syncLessonBusinessRules;

            public GetLessonDetailBySyncLessonIdQueryHandler(IMapper mapper, ISyncLessonRepository syncLessonRepository, SyncLessonBusinessRules syncLessonBusinessRules)
            {
                _mapper = mapper;
                _syncLessonRepository = syncLessonRepository;
                _syncLessonBusinessRules = syncLessonBusinessRules;
            }

            public async Task<GetLessonDetailBySyncLessonIdResponse> Handle(GetLessonDetailBySyncLessonIdQuery request, CancellationToken cancellationToken)
            {
                SyncLesson? syncLesson = await _syncLessonRepository.GetAsync(predicate: sl => sl.Id == request.Id,
                    include: sl => sl.Include(sl => sl.Course).ThenInclude(sl=>sl.CourseInstructors).ThenInclude(i => i.Instructor)
                    .Include(sl => sl.Course),
                   cancellationToken: cancellationToken);
                await _syncLessonBusinessRules.SyncLessonShouldExistWhenSelected(syncLesson);
                GetLessonDetailBySyncLessonIdResponse response = _mapper.Map<GetLessonDetailBySyncLessonIdResponse>(syncLesson);
                return response;
            }
        }
    }
}
