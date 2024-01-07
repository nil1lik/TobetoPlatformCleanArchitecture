using Application.Features.LessonTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonTypes.Queries.GetById;

public class GetByIdLessonTypeQuery : IRequest<GetByIdLessonTypeResponse>
{
    public int Id { get; set; }

    public class GetByIdLessonTypeQueryHandler : IRequestHandler<GetByIdLessonTypeQuery, GetByIdLessonTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonTypeRepository _lessonTypeRepository;
        private readonly LessonTypeBusinessRules _lessonTypeBusinessRules;

        public GetByIdLessonTypeQueryHandler(IMapper mapper, ILessonTypeRepository lessonTypeRepository, LessonTypeBusinessRules lessonTypeBusinessRules)
        {
            _mapper = mapper;
            _lessonTypeRepository = lessonTypeRepository;
            _lessonTypeBusinessRules = lessonTypeBusinessRules;
        }

        public async Task<GetByIdLessonTypeResponse> Handle(GetByIdLessonTypeQuery request, CancellationToken cancellationToken)
        {
            LessonType? lessonType = await _lessonTypeRepository.GetAsync(predicate: lt => lt.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonTypeBusinessRules.LessonTypeShouldExistWhenSelected(lessonType);

            GetByIdLessonTypeResponse response = _mapper.Map<GetByIdLessonTypeResponse>(lessonType);
            return response;
        }
    }
}