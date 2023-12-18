using Application.Features.CourseLessons.Constants;
using Application.Features.CourseLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseLessons.Commands.Delete;

public class DeleteCourseLessonCommand : IRequest<DeletedCourseLessonResponse>
{
    public int Id { get; set; }

    public class DeleteCourseLessonCommandHandler : IRequestHandler<DeleteCourseLessonCommand, DeletedCourseLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseLessonRepository _courseLessonRepository;
        private readonly CourseLessonBusinessRules _courseLessonBusinessRules;

        public DeleteCourseLessonCommandHandler(IMapper mapper, ICourseLessonRepository courseLessonRepository,
                                         CourseLessonBusinessRules courseLessonBusinessRules)
        {
            _mapper = mapper;
            _courseLessonRepository = courseLessonRepository;
            _courseLessonBusinessRules = courseLessonBusinessRules;
        }

        public async Task<DeletedCourseLessonResponse> Handle(DeleteCourseLessonCommand request, CancellationToken cancellationToken)
        {
            CourseLesson? courseLesson = await _courseLessonRepository.GetAsync(predicate: cl => cl.Id == request.Id, cancellationToken: cancellationToken);
            await _courseLessonBusinessRules.CourseLessonShouldExistWhenSelected(courseLesson);

            await _courseLessonRepository.DeleteAsync(courseLesson!);

            DeletedCourseLessonResponse response = _mapper.Map<DeletedCourseLessonResponse>(courseLesson);
            return response;
        }
    }
}