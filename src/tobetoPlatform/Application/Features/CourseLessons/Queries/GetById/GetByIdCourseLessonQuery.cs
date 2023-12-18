using Application.Features.CourseLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseLessons.Queries.GetById;

public class GetByIdCourseLessonQuery : IRequest<GetByIdCourseLessonResponse>
{
    public int Id { get; set; }

    public class GetByIdCourseLessonQueryHandler : IRequestHandler<GetByIdCourseLessonQuery, GetByIdCourseLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseLessonRepository _courseLessonRepository;
        private readonly CourseLessonBusinessRules _courseLessonBusinessRules;

        public GetByIdCourseLessonQueryHandler(IMapper mapper, ICourseLessonRepository courseLessonRepository, CourseLessonBusinessRules courseLessonBusinessRules)
        {
            _mapper = mapper;
            _courseLessonRepository = courseLessonRepository;
            _courseLessonBusinessRules = courseLessonBusinessRules;
        }

        public async Task<GetByIdCourseLessonResponse> Handle(GetByIdCourseLessonQuery request, CancellationToken cancellationToken)
        {
            CourseLesson? courseLesson = await _courseLessonRepository.GetAsync(predicate: cl => cl.Id == request.Id, cancellationToken: cancellationToken);
            await _courseLessonBusinessRules.CourseLessonShouldExistWhenSelected(courseLesson);

            GetByIdCourseLessonResponse response = _mapper.Map<GetByIdCourseLessonResponse>(courseLesson);
            return response;
        }
    }
}