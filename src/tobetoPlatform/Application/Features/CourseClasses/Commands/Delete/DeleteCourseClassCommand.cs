using Application.Features.CourseClasses.Constants;
using Application.Features.CourseClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseClasses.Commands.Delete;

public class DeleteCourseClassCommand : IRequest<DeletedCourseClassResponse>
{
    public int Id { get; set; }

    public class DeleteCourseClassCommandHandler : IRequestHandler<DeleteCourseClassCommand, DeletedCourseClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseClassRepository _courseClassRepository;
        private readonly CourseClassBusinessRules _courseClassBusinessRules;

        public DeleteCourseClassCommandHandler(IMapper mapper, ICourseClassRepository courseClassRepository,
                                         CourseClassBusinessRules courseClassBusinessRules)
        {
            _mapper = mapper;
            _courseClassRepository = courseClassRepository;
            _courseClassBusinessRules = courseClassBusinessRules;
        }

        public async Task<DeletedCourseClassResponse> Handle(DeleteCourseClassCommand request, CancellationToken cancellationToken)
        {
            CourseClass? courseClass = await _courseClassRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _courseClassBusinessRules.CourseClassShouldExistWhenSelected(courseClass);

            await _courseClassRepository.DeleteAsync(courseClass!);

            DeletedCourseClassResponse response = _mapper.Map<DeletedCourseClassResponse>(courseClass);
            return response;
        }
    }
}