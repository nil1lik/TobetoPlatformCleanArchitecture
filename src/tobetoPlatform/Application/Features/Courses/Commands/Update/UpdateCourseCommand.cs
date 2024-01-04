using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Courses.Commands.Update;

public class UpdateCourseCommand : IRequest<UpdatedCourseResponse>
{
    public int Id { get; set; }
    public int EducationPathId { get; set; }
    public string Name { get; set; }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, UpdatedCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseBusinessRules _courseBusinessRules;

        public UpdateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository,
                                         CourseBusinessRules courseBusinessRules)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _courseBusinessRules = courseBusinessRules;
        }

        public async Task<UpdatedCourseResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _courseBusinessRules.CourseShouldExistWhenSelected(course);
            course = _mapper.Map(request, course);

            await _courseRepository.UpdateAsync(course!);

            UpdatedCourseResponse response = _mapper.Map<UpdatedCourseResponse>(course);
            return response;
        }
    }
}