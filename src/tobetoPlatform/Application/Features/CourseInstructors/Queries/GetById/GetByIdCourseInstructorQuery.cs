using Application.Features.CourseInstructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseInstructors.Queries.GetById;

public class GetByIdCourseInstructorQuery : IRequest<GetByIdCourseInstructorResponse>
{
    public int Id { get; set; }

    public class GetByIdCourseInstructorQueryHandler : IRequestHandler<GetByIdCourseInstructorQuery, GetByIdCourseInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseInstructorRepository _courseInstructorRepository;
        private readonly CourseInstructorBusinessRules _courseInstructorBusinessRules;

        public GetByIdCourseInstructorQueryHandler(IMapper mapper, ICourseInstructorRepository courseInstructorRepository, CourseInstructorBusinessRules courseInstructorBusinessRules)
        {
            _mapper = mapper;
            _courseInstructorRepository = courseInstructorRepository;
            _courseInstructorBusinessRules = courseInstructorBusinessRules;
        }

        public async Task<GetByIdCourseInstructorResponse> Handle(GetByIdCourseInstructorQuery request, CancellationToken cancellationToken)
        {
            CourseInstructor? courseInstructor = await _courseInstructorRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _courseInstructorBusinessRules.CourseInstructorShouldExistWhenSelected(courseInstructor);

            GetByIdCourseInstructorResponse response = _mapper.Map<GetByIdCourseInstructorResponse>(courseInstructor);
            return response;
        }
    }
}