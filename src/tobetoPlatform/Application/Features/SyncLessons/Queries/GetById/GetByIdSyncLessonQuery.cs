using Application.Features.SyncLessons.Constants;
using Application.Features.SyncLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.SyncLessons.Queries.GetById;

public class GetByIdSyncLessonQuery : IRequest<GetByIdSyncLessonResponse>
{
    public int Id { get; set; }

    public class GetByIdSyncLessonQueryHandler : IRequestHandler<GetByIdSyncLessonQuery, GetByIdSyncLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISyncLessonRepository _syncLessonRepository;
        private readonly SyncLessonBusinessRules _syncLessonBusinessRules;

        public GetByIdSyncLessonQueryHandler(IMapper mapper, ISyncLessonRepository syncLessonRepository, SyncLessonBusinessRules syncLessonBusinessRules)
        {
            _mapper = mapper;
            _syncLessonRepository = syncLessonRepository;
            _syncLessonBusinessRules = syncLessonBusinessRules;
        }

        public async Task<GetByIdSyncLessonResponse> Handle(GetByIdSyncLessonQuery request, CancellationToken cancellationToken)
        {
            SyncLesson? syncLesson = await _syncLessonRepository.GetAsync(predicate: sl => sl.Id == request.Id, cancellationToken: cancellationToken);
            await _syncLessonBusinessRules.SyncLessonShouldExistWhenSelected(syncLesson);
            GetByIdSyncLessonResponse response = _mapper.Map<GetByIdSyncLessonResponse>(syncLesson);

            LessonSituation(syncLesson, response);

            return response;
        }

        private static void LessonSituation(SyncLesson? syncLesson, GetByIdSyncLessonResponse response)
        {
            DateTime time = DateTime.Now;

            if (syncLesson.StartDate > time)
            {
                response.LessonSituation = "Oturum Henüz Baþlamadý";
            }

            else if (syncLesson.StartDate == time)
            {
                response.LessonSituation = "Oturum Devam Ediyor";
            }

            else if (syncLesson.StartDate < time && syncLesson.IsJoin == true)
            {
                response.LessonSituation = "Katýldýn";
            }

            else if (syncLesson.StartDate < time && syncLesson.IsJoin == false)
            {
                response.LessonSituation = "Katýlmadýn";
            }
        }
    }

}