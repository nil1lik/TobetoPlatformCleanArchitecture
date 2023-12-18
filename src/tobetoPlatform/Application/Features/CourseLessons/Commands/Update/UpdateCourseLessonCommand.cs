using Application.Features.CourseLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseLessons.Commands.Update;

public class UpdateCourseLessonCommand : IRequest<UpdatedCourseLessonResponse>
{
    public int Id { get; set; }

    public class UpdateCourseLessonCommandHandler : IRequestHandler<UpdateCourseLessonCommand, UpdatedCourseLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseLessonRepository _courseLessonRepository;
        private readonly CourseLessonBusinessRules _courseLessonBusinessRules;

        public UpdateCourseLessonCommandHandler(IMapper mapper, ICourseLessonRepository courseLessonRepository,
                                         CourseLessonBusinessRules courseLessonBusinessRules)
        {
            _mapper = mapper;
            _courseLessonRepository = courseLessonRepository;
            _courseLessonBusinessRules = courseLessonBusinessRules;
        }

        public async Task<UpdatedCourseLessonResponse> Handle(UpdateCourseLessonCommand request, CancellationToken cancellationToken)
        {
            CourseLesson? courseLesson = await _courseLessonRepository.GetAsync(predicate: cl => cl.Id == request.Id, cancellationToken: cancellationToken);
            await _courseLessonBusinessRules.CourseLessonShouldExistWhenSelected(courseLesson);
            courseLesson = _mapper.Map(request, courseLesson);

            await _courseLessonRepository.UpdateAsync(courseLesson!);

            UpdatedCourseLessonResponse response = _mapper.Map<UpdatedCourseLessonResponse>(courseLesson);
            return response;
        }
    }
}