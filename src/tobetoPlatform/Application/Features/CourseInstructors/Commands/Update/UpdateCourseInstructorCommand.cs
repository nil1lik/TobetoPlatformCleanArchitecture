using Application.Features.CourseInstructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseInstructors.Commands.Update;

public class UpdateCourseInstructorCommand : IRequest<UpdatedCourseInstructorResponse>
{
    public int Id { get; set; }

    public class UpdateCourseInstructorCommandHandler : IRequestHandler<UpdateCourseInstructorCommand, UpdatedCourseInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseInstructorRepository _courseInstructorRepository;
        private readonly CourseInstructorBusinessRules _courseInstructorBusinessRules;

        public UpdateCourseInstructorCommandHandler(IMapper mapper, ICourseInstructorRepository courseInstructorRepository,
                                         CourseInstructorBusinessRules courseInstructorBusinessRules)
        {
            _mapper = mapper;
            _courseInstructorRepository = courseInstructorRepository;
            _courseInstructorBusinessRules = courseInstructorBusinessRules;
        }

        public async Task<UpdatedCourseInstructorResponse> Handle(UpdateCourseInstructorCommand request, CancellationToken cancellationToken)
        {
            CourseInstructor? courseInstructor = await _courseInstructorRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _courseInstructorBusinessRules.CourseInstructorShouldExistWhenSelected(courseInstructor);
            courseInstructor = _mapper.Map(request, courseInstructor);

            await _courseInstructorRepository.UpdateAsync(courseInstructor!);

            UpdatedCourseInstructorResponse response = _mapper.Map<UpdatedCourseInstructorResponse>(courseInstructor);
            return response;
        }
    }
}