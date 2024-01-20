using Application.Features.SyncLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SyncLessons.Commands.Create;

public class CreateSyncLessonCommand : IRequest<CreatedSyncLessonResponse>
{
    public int LessonVideoDetailId { get; set; }
    public int CourseId { get; set; }
    public string SyncVideoUrl { get; set; }
    public string SessionName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    //public TimeSpan Time { get; set; }
    public bool IsJoin { get; set; }

    public class CreateSyncLessonCommandHandler : IRequestHandler<CreateSyncLessonCommand, CreatedSyncLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISyncLessonRepository _syncLessonRepository;
        private readonly SyncLessonBusinessRules _syncLessonBusinessRules;

        public CreateSyncLessonCommandHandler(IMapper mapper, ISyncLessonRepository syncLessonRepository,
                                         SyncLessonBusinessRules syncLessonBusinessRules)
        {
            _mapper = mapper;
            _syncLessonRepository = syncLessonRepository;
            _syncLessonBusinessRules = syncLessonBusinessRules;
        }

        public async Task<CreatedSyncLessonResponse> Handle(CreateSyncLessonCommand request, CancellationToken cancellationToken)
        {
            SyncLesson syncLesson = _mapper.Map<SyncLesson>(request);

            await _syncLessonRepository.AddAsync(syncLesson);

            CreatedSyncLessonResponse response = _mapper.Map<CreatedSyncLessonResponse>(syncLesson);
            return response;
        }
    }
}