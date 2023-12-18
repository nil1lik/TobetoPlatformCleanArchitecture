using Application.Features.AsyncLessons.Constants;
using Application.Features.AsyncLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AsyncLessons.Commands.Delete;

public class DeleteAsyncLessonCommand : IRequest<DeletedAsyncLessonResponse>
{
    public int Id { get; set; }

    public class DeleteAsyncLessonCommandHandler : IRequestHandler<DeleteAsyncLessonCommand, DeletedAsyncLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncLessonRepository _asyncLessonRepository;
        private readonly AsyncLessonBusinessRules _asyncLessonBusinessRules;

        public DeleteAsyncLessonCommandHandler(IMapper mapper, IAsyncLessonRepository asyncLessonRepository,
                                         AsyncLessonBusinessRules asyncLessonBusinessRules)
        {
            _mapper = mapper;
            _asyncLessonRepository = asyncLessonRepository;
            _asyncLessonBusinessRules = asyncLessonBusinessRules;
        }

        public async Task<DeletedAsyncLessonResponse> Handle(DeleteAsyncLessonCommand request, CancellationToken cancellationToken)
        {
            AsyncLesson? asyncLesson = await _asyncLessonRepository.GetAsync(predicate: al => al.Id == request.Id, cancellationToken: cancellationToken);
            await _asyncLessonBusinessRules.AsyncLessonShouldExistWhenSelected(asyncLesson);

            await _asyncLessonRepository.DeleteAsync(asyncLesson!);

            DeletedAsyncLessonResponse response = _mapper.Map<DeletedAsyncLessonResponse>(asyncLesson);
            return response;
        }
    }
}