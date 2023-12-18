using Application.Features.CourseInstructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseInstructors.Commands.Create;

public class CreateCourseInstructorCommand : IRequest<CreatedCourseInstructorResponse>
{

    public class CreateCourseInstructorCommandHandler : IRequestHandler<CreateCourseInstructorCommand, CreatedCourseInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseInstructorRepository _courseInstructorRepository;
        private readonly CourseInstructorBusinessRules _courseInstructorBusinessRules;

        public CreateCourseInstructorCommandHandler(IMapper mapper, ICourseInstructorRepository courseInstructorRepository,
                                         CourseInstructorBusinessRules courseInstructorBusinessRules)
        {
            _mapper = mapper;
            _courseInstructorRepository = courseInstructorRepository;
            _courseInstructorBusinessRules = courseInstructorBusinessRules;
        }

        public async Task<CreatedCourseInstructorResponse> Handle(CreateCourseInstructorCommand request, CancellationToken cancellationToken)
        {
            CourseInstructor courseInstructor = _mapper.Map<CourseInstructor>(request);

            await _courseInstructorRepository.AddAsync(courseInstructor);

            CreatedCourseInstructorResponse response = _mapper.Map<CreatedCourseInstructorResponse>(courseInstructor);
            return response;
        }
    }
}