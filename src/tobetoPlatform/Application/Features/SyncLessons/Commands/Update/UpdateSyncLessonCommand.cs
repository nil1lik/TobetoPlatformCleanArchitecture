using Application.Features.SyncLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SyncLessons.Commands.Update;

public class UpdateSyncLessonCommand : IRequest<UpdatedSyncLessonResponse>
{
    public int Id { get; set; }
    public int LessonVideoDetailId { get; set; }
    public int CourseId { get; set; }
    public string SyncVideoUrl { get; set; }
    public string SessionName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan Time { get; set; }
    public bool IsJoin { get; set; }

    public class UpdateSyncLessonCommandHandler : IRequestHandler<UpdateSyncLessonCommand, UpdatedSyncLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISyncLessonRepository _syncLessonRepository;
        private readonly SyncLessonBusinessRules _syncLessonBusinessRules;

        public UpdateSyncLessonCommandHandler(IMapper mapper, ISyncLessonRepository syncLessonRepository,
                                         SyncLessonBusinessRules syncLessonBusinessRules)
        {
            _mapper = mapper;
            _syncLessonRepository = syncLessonRepository;
            _syncLessonBusinessRules = syncLessonBusinessRules;
        }

        public async Task<UpdatedSyncLessonResponse> Handle(UpdateSyncLessonCommand request, CancellationToken cancellationToken)
        {
            SyncLesson? syncLesson = await _syncLessonRepository.GetAsync(predicate: sl => sl.Id == request.Id, cancellationToken: cancellationToken);
            await _syncLessonBusinessRules.SyncLessonShouldExistWhenSelected(syncLesson);
            syncLesson = _mapper.Map(request, syncLesson);

            await _syncLessonRepository.UpdateAsync(syncLesson!);

            UpdatedSyncLessonResponse response = _mapper.Map<UpdatedSyncLessonResponse>(syncLesson);
            return response;
        }
    }
}