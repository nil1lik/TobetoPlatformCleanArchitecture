using Application.Features.CourseClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseClasses.Commands.Update;

public class UpdateCourseClassCommand : IRequest<UpdatedCourseClassResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateCourseClassCommandHandler : IRequestHandler<UpdateCourseClassCommand, UpdatedCourseClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseClassRepository _courseClassRepository;
        private readonly CourseClassBusinessRules _courseClassBusinessRules;

        public UpdateCourseClassCommandHandler(IMapper mapper, ICourseClassRepository courseClassRepository,
                                         CourseClassBusinessRules courseClassBusinessRules)
        {
            _mapper = mapper;
            _courseClassRepository = courseClassRepository;
            _courseClassBusinessRules = courseClassBusinessRules;
        }

        public async Task<UpdatedCourseClassResponse> Handle(UpdateCourseClassCommand request, CancellationToken cancellationToken)
        {
            CourseClass? courseClass = await _courseClassRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _courseClassBusinessRules.CourseClassShouldExistWhenSelected(courseClass);
            courseClass = _mapper.Map(request, courseClass);

            await _courseClassRepository.UpdateAsync(courseClass!);

            UpdatedCourseClassResponse response = _mapper.Map<UpdatedCourseClassResponse>(courseClass);
            return response;
        }
    }
}