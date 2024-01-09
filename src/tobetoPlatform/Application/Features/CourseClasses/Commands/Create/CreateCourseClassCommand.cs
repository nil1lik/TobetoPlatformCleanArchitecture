using Application.Features.CourseClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseClasses.Commands.Create;

public class CreateCourseClassCommand : IRequest<CreatedCourseClassResponse>
{
    public string Name { get; set; }

    public class CreateCourseClassCommandHandler : IRequestHandler<CreateCourseClassCommand, CreatedCourseClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseClassRepository _courseClassRepository;
        private readonly CourseClassBusinessRules _courseClassBusinessRules;

        public CreateCourseClassCommandHandler(IMapper mapper, ICourseClassRepository courseClassRepository,
                                         CourseClassBusinessRules courseClassBusinessRules)
        {
            _mapper = mapper;
            _courseClassRepository = courseClassRepository;
            _courseClassBusinessRules = courseClassBusinessRules;
        }

        public async Task<CreatedCourseClassResponse> Handle(CreateCourseClassCommand request, CancellationToken cancellationToken)
        {
            CourseClass courseClass = _mapper.Map<CourseClass>(request);

            await _courseClassRepository.AddAsync(courseClass);

            CreatedCourseClassResponse response = _mapper.Map<CreatedCourseClassResponse>(courseClass);
            return response;
        }
    }
}