using Application.Features.CourseLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseLessons.Commands.Create;

public class CreateCourseLessonCommand : IRequest<CreatedCourseLessonResponse>
{
    public int CourseId { get; set; }
    public int AsyncLessonId { get; set; }

    public class CreateCourseLessonCommandHandler : IRequestHandler<CreateCourseLessonCommand, CreatedCourseLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseLessonRepository _courseLessonRepository;
        private readonly CourseLessonBusinessRules _courseLessonBusinessRules;

        public CreateCourseLessonCommandHandler(IMapper mapper, ICourseLessonRepository courseLessonRepository,
                                         CourseLessonBusinessRules courseLessonBusinessRules)
        {
            _mapper = mapper;
            _courseLessonRepository = courseLessonRepository;
            _courseLessonBusinessRules = courseLessonBusinessRules;
        }

        public async Task<CreatedCourseLessonResponse> Handle(CreateCourseLessonCommand request, CancellationToken cancellationToken)
        {
            CourseLesson courseLesson = _mapper.Map<CourseLesson>(request);

            await _courseLessonRepository.AddAsync(courseLesson);

            CreatedCourseLessonResponse response = _mapper.Map<CreatedCourseLessonResponse>(courseLesson);
            return response;
        }
    }
}