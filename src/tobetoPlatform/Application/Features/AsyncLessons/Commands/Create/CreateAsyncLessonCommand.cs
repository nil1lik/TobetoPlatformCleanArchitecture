using Application.Features.AsyncLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
 
namespace Application.Features.AsyncLessons.Commands.Create;

public class CreateAsyncLessonCommand : IRequest<CreatedAsyncLessonResponse>
{
    public int LessonVideoDetailId { get; set; }
    public int VideoCategoryId { get; set; }
    public int LessonTypeId { get; set; }
    public string Name { get; set; }
    public TimeSpan Time { get; set; }
    public double VideoPoint { get; set; }
    public string VideoUrl { get; set; }
    public bool IsCompleted { get; set; }

    public class CreateAsyncLessonCommandHandler : IRequestHandler<CreateAsyncLessonCommand, CreatedAsyncLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncLessonRepository _asyncLessonRepository;
        private readonly AsyncLessonBusinessRules _asyncLessonBusinessRules;

        public CreateAsyncLessonCommandHandler(IMapper mapper, IAsyncLessonRepository asyncLessonRepository,
                                         AsyncLessonBusinessRules asyncLessonBusinessRules)
        {
            _mapper = mapper;
            _asyncLessonRepository = asyncLessonRepository;
            _asyncLessonBusinessRules = asyncLessonBusinessRules;
        }

        public async Task<CreatedAsyncLessonResponse> Handle(CreateAsyncLessonCommand request, CancellationToken cancellationToken)
        {
            AsyncLesson asyncLesson = _mapper.Map<AsyncLesson>(request);

            await _asyncLessonRepository.AddAsync(asyncLesson);

            CreatedAsyncLessonResponse response = _mapper.Map<CreatedAsyncLessonResponse>(asyncLesson);
            return response;
        }
    }
}