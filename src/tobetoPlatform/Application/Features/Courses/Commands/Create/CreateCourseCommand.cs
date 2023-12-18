using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Courses.Commands.Create;

public class CreateCourseCommand : IRequest<CreatedCourseResponse>
{
    public int EducationPathId { get; set; }
    public int CourseLessonId { get; set; }
    public string Name { get; set; }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreatedCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseBusinessRules _courseBusinessRules;

        public CreateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository,
                                         CourseBusinessRules courseBusinessRules)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _courseBusinessRules = courseBusinessRules;
        }

        public async Task<CreatedCourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            Course course = _mapper.Map<Course>(request);

            await _courseRepository.AddAsync(course);

            CreatedCourseResponse response = _mapper.Map<CreatedCourseResponse>(course);
            return response;
        }
    }
}