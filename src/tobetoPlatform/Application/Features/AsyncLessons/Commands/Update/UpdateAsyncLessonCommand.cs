using Application.Features.AsyncLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AsyncLessons.Commands.Update;

public class UpdateAsyncLessonCommand : IRequest<UpdatedAsyncLessonResponse>
{
    public int Id { get; set; }
    public int LessonVideoDetailId { get; set; }
    public int VideoCategoryId { get; set; }
    public int LessonTypeId { get; set; }
    public string Name { get; set; }
    public double VideoPoint { get; set; }
    public TimeSpan Time { get; set; }
    public string VideoUrl { get; set; }
    public bool IsCompleted { get; set; }

    public class UpdateAsyncLessonCommandHandler : IRequestHandler<UpdateAsyncLessonCommand, UpdatedAsyncLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncLessonRepository _asyncLessonRepository;
        private readonly AsyncLessonBusinessRules _asyncLessonBusinessRules;

        public UpdateAsyncLessonCommandHandler(IMapper mapper, IAsyncLessonRepository asyncLessonRepository,
                                         AsyncLessonBusinessRules asyncLessonBusinessRules)
        {
            _mapper = mapper;
            _asyncLessonRepository = asyncLessonRepository;
            _asyncLessonBusinessRules = asyncLessonBusinessRules;
        }

        public async Task<UpdatedAsyncLessonResponse> Handle(UpdateAsyncLessonCommand request, CancellationToken cancellationToken)
        {
            AsyncLesson? asyncLesson = await _asyncLessonRepository.GetAsync(predicate: al => al.Id == request.Id, cancellationToken: cancellationToken);
            await _asyncLessonBusinessRules.AsyncLessonShouldExistWhenSelected(asyncLesson);
            asyncLesson = _mapper.Map(request, asyncLesson);

            await _asyncLessonRepository.UpdateAsync(asyncLesson!);

            UpdatedAsyncLessonResponse response = _mapper.Map<UpdatedAsyncLessonResponse>(asyncLesson);
            return response;
        }
    }
}