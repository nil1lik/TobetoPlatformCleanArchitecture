using Application.Features.CourseClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseClasses.Queries.GetById;

public class GetByIdCourseClassQuery : IRequest<GetByIdCourseClassResponse>
{
    public int Id { get; set; }

    public class GetByIdCourseClassQueryHandler : IRequestHandler<GetByIdCourseClassQuery, GetByIdCourseClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseClassRepository _courseClassRepository;
        private readonly CourseClassBusinessRules _courseClassBusinessRules;

        public GetByIdCourseClassQueryHandler(IMapper mapper, ICourseClassRepository courseClassRepository, CourseClassBusinessRules courseClassBusinessRules)
        {
            _mapper = mapper;
            _courseClassRepository = courseClassRepository;
            _courseClassBusinessRules = courseClassBusinessRules;
        }

        public async Task<GetByIdCourseClassResponse> Handle(GetByIdCourseClassQuery request, CancellationToken cancellationToken)
        {
            CourseClass? courseClass = await _courseClassRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _courseClassBusinessRules.CourseClassShouldExistWhenSelected(courseClass);

            GetByIdCourseClassResponse response = _mapper.Map<GetByIdCourseClassResponse>(courseClass);
            return response;
        }
    }
}