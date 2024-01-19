using Application.Features.CourseInstructors.Constants;
using Application.Features.CourseInstructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseInstructors.Commands.Delete;

public class DeleteCourseInstructorCommand : IRequest<DeletedCourseInstructorResponse>
{
    public int Id { get; set; }

    public class DeleteCourseInstructorCommandHandler : IRequestHandler<DeleteCourseInstructorCommand, DeletedCourseInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseInstructorRepository _courseInstructorRepository;
        private readonly CourseInstructorBusinessRules _courseInstructorBusinessRules;

        public DeleteCourseInstructorCommandHandler(IMapper mapper, ICourseInstructorRepository courseInstructorRepository,
                                         CourseInstructorBusinessRules courseInstructorBusinessRules)
        {
            _mapper = mapper;
            _courseInstructorRepository = courseInstructorRepository;
            _courseInstructorBusinessRules = courseInstructorBusinessRules;
        }

        public async Task<DeletedCourseInstructorResponse> Handle(DeleteCourseInstructorCommand request, CancellationToken cancellationToken)
        {
            CourseInstructor? courseInstructor = await _courseInstructorRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _courseInstructorBusinessRules.CourseInstructorShouldExistWhenSelected(courseInstructor);

            await _courseInstructorRepository.DeleteAsync(courseInstructor!);

            DeletedCourseInstructorResponse response = _mapper.Map<DeletedCourseInstructorResponse>(courseInstructor);
            return response;
        }
    }
}