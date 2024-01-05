using Application.Features.SyncLessons.Constants;
using Application.Features.SyncLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SyncLessons.Commands.Delete;

public class DeleteSyncLessonCommand : IRequest<DeletedSyncLessonResponse>
{
    public int Id { get; set; }

    public class DeleteSyncLessonCommandHandler : IRequestHandler<DeleteSyncLessonCommand, DeletedSyncLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISyncLessonRepository _syncLessonRepository;
        private readonly SyncLessonBusinessRules _syncLessonBusinessRules;

        public DeleteSyncLessonCommandHandler(IMapper mapper, ISyncLessonRepository syncLessonRepository,
                                         SyncLessonBusinessRules syncLessonBusinessRules)
        {
            _mapper = mapper;
            _syncLessonRepository = syncLessonRepository;
            _syncLessonBusinessRules = syncLessonBusinessRules;
        }

        public async Task<DeletedSyncLessonResponse> Handle(DeleteSyncLessonCommand request, CancellationToken cancellationToken)
        {
            SyncLesson? syncLesson = await _syncLessonRepository.GetAsync(predicate: sl => sl.Id == request.Id, cancellationToken: cancellationToken);
            await _syncLessonBusinessRules.SyncLessonShouldExistWhenSelected(syncLesson);

            await _syncLessonRepository.DeleteAsync(syncLesson!);

            DeletedSyncLessonResponse response = _mapper.Map<DeletedSyncLessonResponse>(syncLesson);
            return response;
        }
    }
}